using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;

    //プレイヤーの基本情報；
    public float MoveSpeed;
    private float moveup = 5.0f;
    private bool isJump = false;

    private Talk_Checker talk_checker;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        talk_checker = GetComponent<Talk_Checker>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   public enum playerstate
    {
        normal,
        talk,
        choose,
    }

    // Update is called once per frame
    void Update()
    {
        //Wキー(前方移動)
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * MoveSpeed);
        }
        //Sキー(前方移動)
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * MoveSpeed);
        }
        //Aキー(前方移動)
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * MoveSpeed);
        }
        //Dキー(前方移動)
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * MoveSpeed);
        }
        //スペースキーでジャンプ
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            rb.AddForce(transform.up * moveup, ForceMode.Impulse);
            isJump = true;
        }

        SpeedControl();
       
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (talk_checker.talk_npc!=null)
            {                
                DialogueManager.instance.StartDialogue(talk_checker.talk_npc.dialogue_text);
            }
            else
            {
                Debug.Log("eeeeeeeeeee");
            }

        }

        //if(Time.timeScale==0.0f)
        //{
        //    choose();
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    private void SpeedControl()
    {
        //プレイヤーのスピードを制限
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    //private void choose()
    //{
    //    //Vector3 origin = new Vector3(0, 0, 0); // 原点
    //    //Vector3 direction = new Vector3(1, 0, 0); // X軸方向を表すベクトル
    //    //Ray ray = new Ray(origin, direction); // Rayを生成

    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        RaycastHit hit ;

    //        if (Physics.Raycast(ray, out hit))
    //        {



    //            if (hit.collider != null && hit.collider.gameObject.CompareTag("Finish"))
    //            {
    //                DialogueOption myoption = hit.collider.gameObject.GetComponent<DialogueOption>();

    //                DialogueManager.instance.StartDialogue(myoption.Next_Dialogue);

    //                Debug.Log("asdf");
    //            }
    //            else
    //            {
    //                Debug.Log("null");
    //            }
    //        }
    //    }
    //}

}
