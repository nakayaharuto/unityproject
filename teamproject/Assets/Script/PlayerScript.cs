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
        talk_checker = GetComponent <Talk_Checker>();
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
                DialogueManager.instance.StartDialogue(talk_checker.talk_npc);
                //DialogueManager.instance.DisplaySentence(talk_checker.talk_npc);
            }
            else
            {
                Debug.Log("eeeeeeeeeee");
            }

           


        }

        

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
}
