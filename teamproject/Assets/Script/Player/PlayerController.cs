using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
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
    public Transform throwOrigin;
    public float throwForce = 10f;
    public Trajectory trajectoryDrawer;

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

        //Fキー入力
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractWithItem();
        }

        if(Input.GetMouseButton(0))
        {
            Item item = ItemBox.instance.GetSelectedItem();
            if (item != null)
            {
                Vector3 start = throwOrigin.position;
                Vector3 velocity = Camera.main.transform.forward * throwForce;
                trajectoryDrawer.DrawTrajectory(start, velocity);
            }
        }

        //左クリック入力
        if(Input.GetMouseButtonUp(0))
        {
            ThrowSelectedItem();
        }

        //軌道を常に表示
        DrawTrajectoryPreview();
    }

    //アイテム入手部分
    void InteractWithItem()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        //Rayの角度の表示
        Debug.DrawRay(origin , direction * interactRange, Color.red, 1.0f);

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
        else
        {
            Debug.Log("何も当たっていない");
        }
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

    //アイテム投げる
    void ThrowSelectedItem()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item == null || item.throwprefab == null) return;

        GameObject obj = Instantiate(item.throwprefab, throwOrigin.position, Quaternion.identity);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        Debug.Log("HIT");
        if (rb != null)
        {
            Debug.Log("ポイ");
            rb.velocity = Camera.main.transform.forward * throwForce;
        }
        else
        {
            Debug.LogWarning("Rigidbody が見つかりません！");
        }

        //選択してるアイテムを使ったら削除
        ItemBox.instance.UseSelectItem();
        //軌道を消す
        trajectoryDrawer.ClearTrajectory();
    }

}
