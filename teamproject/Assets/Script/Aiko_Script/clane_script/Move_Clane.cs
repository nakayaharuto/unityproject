using UnityEngine;

public class Move_Clane : MonoBehaviour
{
    [SerializeField] public bool hit = false;
    [SerializeField] public bool rail_hit = true;
    [SerializeField] public bool item_hit = false;
    [SerializeField] public GameObject get_item;
    Vector3 StartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (item_hit==true)
        {
            get_item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-0.3f, this.transform.position.z);
        }
       
 

        // float posY = StartPos.y + Mathf.Sin(Time.time) * 4;
        //transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("lll");

        if (other.gameObject.CompareTag("box") /*|| other.gameObject.CompareTag("Ground")*/)
        {
            //this.transform.SetParent(other.transform.parent);

            get_item = other.gameObject;

             
            item_hit = true;
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            hit = true;

            Debug.Log(this.transform.position.y);
            Debug.Log("abcdefg");
        }
        else
        {
            Debug.Log("ìñÇΩÇ¡ÇƒÇÀÅ[ÇÊ");
        }

        if (other.gameObject.CompareTag("Ground")|| other.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
        else
        {
            Debug.Log("ìñÇΩÇ¡ÇƒÇÀÅ[ÇÊ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hit = true;

            Debug.Log("bbbbb");
        }
        else
        {
            Debug.Log("ìñÇΩÇ¡ÇƒÇÀÅ[ÇÊ");
        }
    }

}
