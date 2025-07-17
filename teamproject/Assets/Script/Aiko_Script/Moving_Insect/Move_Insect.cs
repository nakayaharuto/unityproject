using UnityEngine;

public class Move_Insect : MonoBehaviour
{
   public float rot_num;
    public float pos_x;
    public bool move_flag = true;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rot_num=this.transform.localEulerAngles.y/90;
        pos_x = this.transform.position.x;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move_flag==true)
        {
            this.transform.Translate(Time.deltaTime, 0, 0);
        }

       
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("qwsdcdcfvggbhh");
            if (rot_num < 3)
            {
                rot_num++;
            }
            else
            {
                rot_num = 0;
            }
            move_flag = false;
            this.transform.localEulerAngles = new Vector3(0, 90f*rot_num, 0);
           
            this.transform.Translate(-0.1f, 0, 0);
           
        }

        if (other.gameObject.CompareTag("DeathZone"))
        {
            GameObject.FindGameObjectWithTag("SummonMachine").GetComponentInChildren<Summon_Insect>().spawn_count--;
            Destroy(this.gameObject);
            
        }

        rb.useGravity = false;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("sairin");
            move_flag = true;
        }

        

    }

}
