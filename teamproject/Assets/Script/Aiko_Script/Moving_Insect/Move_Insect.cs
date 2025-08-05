using UnityEngine;

public class Move_Insect : MonoBehaviour
{
   public float rot_num;
    public float pos_x;
    public bool move_flag = true;
    [SerializeField] Rigidbody rb;
    public bool invation_flag;
    public int rot_plus_mainas;
    [SerializeField] private float start_rot;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_rot = this.transform.localEulerAngles.y;
        //this.transform.localEulerAngles = new Vector3(0f,start_rot,0f);
        //rot_num=this.transform.localEulerAngles.y/90;
        pos_x = this.transform.position.x;
        rb = this.GetComponent<Rigidbody>();
        rot_plus_mainas = -1;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (move_flag==true)
        {
            this.transform.Translate(Time.deltaTime, 0, 0);
        }

        if (rot_num<-3)
        {
            rot_num = 0;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
           
            if (rot_num < 3)
            {
                rot_num++;
            }
            else
            {
                rot_num = 0;
            }
            move_flag = false;
            this.transform.localEulerAngles = new Vector3(0, /*start_rot+*/90f*rot_num*rot_plus_mainas, 0);
           
            this.transform.Translate(-0.1f, 0, 0);
           
        }

        if (other.gameObject.CompareTag("DeathZone")|| other.gameObject.CompareTag("Bullet"))
        {
            GameObject.FindGameObjectWithTag("SummonMachine").GetComponentInChildren<Summon_Insect>().spawn_count--;
            Destroy(this.gameObject);
            
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = false;
           
        }

        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("sairin");
            move_flag = true;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = true;
        }

        if (other.gameObject.CompareTag("test"))
        {
            this.transform.localEulerAngles = new Vector3(0f,start_rot,0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            invation_flag = true;
        }

        if (other.CompareTag("DeathZone"))
        {
            Destroy(this);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            invation_flag = false;
        }
    }



}
