using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;

    //プレイヤーの基本情報；
    private float speed = 3.0f;
    private float moveup = 3.0f;
    private float Cameraspeed = 100f;
    private bool isJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Wキー(前方移動)
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);
        }
        //Sキー(前方移動)
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed);
        }
        //Aキー(前方移動)
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed);
        }
        //Dキー(前方移動)
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed);
        }
        //スペースキーでジャンプ
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            rb.AddForce(transform.up * moveup, ForceMode.Impulse);
            isJump = true;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse x") * Cameraspeed;
            if(Mathf.Abs(x)>0.1f)
            {
                transform.RotateAround(transform.position, Vector3.up, x);
            }
        }
        

        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
