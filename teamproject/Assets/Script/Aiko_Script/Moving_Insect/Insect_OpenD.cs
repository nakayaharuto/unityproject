using UnityEngine;

public class Insect_OpenD : MonoBehaviour
{
    [SerializeField] private bool open_door;
    [SerializeField] private GameObject left_door;
    [SerializeField] private GameObject right_door;
    [SerializeField] private int door_time;
    private Rigidbody rb;
    [SerializeField] private SoundManager SM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        open_door = false;
        //this.GetComponent<Rigidbody>().useGravity = false;
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open_door==true)
        {
            this.GetComponent<Renderer>().material.color = Color.red;

            if (door_time>0)
            {
                left_door.transform.Translate(0.0f, 0.0f, -Time.deltaTime);
                right_door.transform.Translate(0.0f, 0.0f, +Time.deltaTime);
                door_time--;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition
        | RigidbodyConstraints.FreezeRotation;
        this.GetComponent<BoxCollider>().isTrigger = true;
        

        //if (collision.gameObject.CompareTag("EscortTarget"))
        //{
        //    open_door=true;
        //}


    }

    private void OnCollisionStay(Collision collision)
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition
       | RigidbodyConstraints.FreezeRotation;

        if (other.gameObject.CompareTag("EscortTarget"))
        {
            open_door = true;
            SM.Play(SoundManager.SoundType.Open);
        }
    }

}
