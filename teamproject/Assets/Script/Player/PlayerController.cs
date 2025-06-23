using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動関係
    public float WalkSpeed = 3.0f;
    public float RanSpeed = 7.0f;
    public float Graviyty = -9.81f;
    public float JumpHeight = 2f;

    public float interactRange = 2f;
    [SerializeField] LayerMask itemLayer = default;

    //投げる処理
    public Transform throwOrigin;//軌道
    public float throwForce = 10f;
    public Trajectory trajectoryDrawer;

    public Transform HandHoldPoint;
    private GameObject heldItem;
    private Item currentDisplayedItem = null;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemLayer = LayerMask.GetMask("item");//itemレイヤーをとる
        //マウスポインタを表示
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();//キャラクタコントローラを取得

        if (SaveSystem.HasSaveData())
        {
            controller.enabled = false; // 一時的に無効化
            //保存した位置を復元
            Vector3 savedPosition = SaveSystem.LoadPlayerPosition();
            transform.position = savedPosition;
            Debug.Log("Position restored to: " + savedPosition);
            controller.enabled = true; // 有効化
        }

    }

    // Update is called once per frame
    void Update()
    {
        //地面判定
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //移動入力
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //移動処理
        //controller.Move(move * WalkSpeed * Time.deltaTime);

        //歩き
        float dash = Input.GetKey(KeyCode.LeftShift) ? RanSpeed : WalkSpeed;
        //ダッシュ
        controller.Move(move *  dash * Time.deltaTime);
        //ジャンプ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Graviyty);
        }
        //重力
        velocity.y += Graviyty * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        UpdateHeldItemDisplay();

        //Fキー入力
        if (Input.GetKeyDown(KeyCode.F))
        {
            KeyCardDoor();
        }

        if(Input.GetMouseButtonDown(0))
        {
            ThrowHeldItem();
            InteractWithItem();
        }

        if (Input.GetMouseButtonDown(1)) // 右クリック
        {
            PlaceHeldItem();
        }

        //軌道を常に表示
        DrawTrajectoryPreview();
    }

    //表示
    void UpdateHeldItemDisplay()
    {
        Item selectedItem = ItemBox.instance.GetSelectedItem();
        if(selectedItem != currentDisplayedItem)
        {
            currentDisplayedItem = selectedItem;

            //古いobj削除
            if (heldItem != null)
            {
                Destroy(heldItem);
            }

            //新しいItemあるなら表示
            if (selectedItem != null && selectedItem.throwprefab != null)
            {
                heldItem = Instantiate(selectedItem.throwprefab, HandHoldPoint.position,HandHoldPoint.rotation,HandHoldPoint);
                Rigidbody rb = heldItem.GetComponent<Rigidbody>();
                if(rb != null)
                    rb.isKinematic = true;
            }
        }
    }


    //アイテム入手部分
    void InteractWithItem()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        //Rayの角度の表示
        Debug.DrawRay(origin , direction * interactRange, Color.red, 2.0f);

        Ray ray = new Ray(origin,direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, itemLayer))
        {
            Debug.Log("ヒットしたオブジェクト: {hit.collider.gameObject.name}");
            PickupObject pickup = hit.collider.GetComponent<PickupObject>();
            if (pickup != null)
            {
                pickup.OnClickObject();
                Debug.Log("アイテム取得");
            }
        }
        else if(Physics.Raycast(ray, out hit, interactRange, itemLayer))
        {
            Debug.Log("ヒットしたオブジェクト: {hit.collider.gameObject.name}");
            SetObjj setobj = hit.collider.GetComponent<SetObjj>();
            if (setobj != null)
            {
                setobj.OnClickThis();
                Debug.Log("アイテム設置");
            }
        }
        else
        {
            Debug.Log("何も当たっていない");
        }
    }

    //投げる
    void ThrowHeldItem()
    {
        //持ってるitemがnullか表示itemがnullなら処理中断
        if (heldItem == null || currentDisplayedItem == null) return;

        GameObject thrown = Instantiate(currentDisplayedItem.throwprefab,throwOrigin.position,throwOrigin.rotation);
        Rigidbody rb = thrown.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.linearVelocity = Camera.main.transform.forward * throwForce;
        }
        //スロットから削除
        ItemBox.instance.UseSelectItem();
        currentDisplayedItem = null;
        Destroy(heldItem);
        heldItem = null;

        UpdateHeldItemDisplay();
    }

    //置く
    void PlaceHeldItem()
    {
        if (heldItem == null || currentDisplayedItem == null) return;

        Instantiate(currentDisplayedItem.throwprefab, HandHoldPoint.position, HandHoldPoint.rotation);

        // スロットから削除＆表示更新
        ItemBox.instance.UseSelectItem();
        currentDisplayedItem = null;
        Destroy(heldItem);
        heldItem = null;

        UpdateHeldItemDisplay();
    }

    //cardでドアを開く
    void KeyCardDoor()
    {
        if (heldItem == null || currentDisplayedItem == null) return;

        key.instance.KeyDoor();
        key.instance.SetheldItem(heldItem);
       
        UpdateHeldItemDisplay();
    }

    //軌道線
    void DrawTrajectoryPreview()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item == null || item.throwprefab == null)
        { 
            trajectoryDrawer.ClearTrajectory();
            return;
        }

        Vector3 velocity = Camera.main.transform.forward * throwForce;
        trajectoryDrawer.DrawTrajectory(throwOrigin.position, velocity);
    }

}
