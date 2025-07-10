using UnityEngine;

public class Lesar_Flag_Script : MonoBehaviour
{
    public bool Lesar_Flag = true;
    public bool Lesar_Enable = true;
    public GameObject ColLesar;
    [SerializeField] float lesar_pos;
    [SerializeField] float lesar_pos2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("aaaa");
    //    //Lesar_Flag = false;
    //    if (collision.gameObject.CompareTag("Crane"))
    //    {
    //        Lesar_Flag = false;
    //        Debug.Log("bbbb");
    //    }
    //    else
    //    {
    //        Debug.Log("cccc");
    //       // Lesar_Flag = false;
    //    }
    //}

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dddd");
        //Lesar_Flag = false;
        if (other.gameObject.CompareTag("Crane"))
        {
            Lesar_Flag = false;
            Debug.Log("eeee");
            other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Flag = true;
            other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Enable = true;
            ColLesar = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            Lesar_Flag = false;
            Lesar_Enable = false;
            //this.GetComponentInParent<Lesar_Script>().Lesar_Distance = 0f;
            //lesar_pos = this.GetComponentInParent<Lesar_Script>().Lesar_Distance;
           
           
        }
        else if (other.gameObject.CompareTag("gimick_button"))
        {
            other.GetComponent<Lesar_Clear>().lesar_clear = true;
            other.GetComponent<Lesar_Clear>().Clear();
            
            Lesar_Flag = false;
        }
        else
        {
            Debug.Log("ffff");
            Lesar_Flag = false;
        }



    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Respawn"))
    //    {
    //        //lesar_pos = this.GetComponentInParent<Lesar_Script>().Lesar_Distance;
    //        Lesar_Flag = false;

    //        //Lesar_Enable = false;
    //        this.GetComponentInParent<Lesar_Script>().Lesar_Distance = lesar_pos2/10;
    //        //Lesar_Enable = true;
    //        Debug.Log("qwertyuio"+ this.GetComponentInParent<Lesar_Script>().Lesar_Distance);
    //        Debug.Log(lesar_pos+"lesapos");
    //        Debug.Log(lesar_pos2 + "pos2");

    //    }
    //}

    private void OnTriggerExit(Collider other)
    {

        
        if (other.gameObject.CompareTag("Crane"))
        {
            other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Enable = false;
            //other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Flag = false;
           
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            //lesar_pos2 = lesar_pos;
            Lesar_Flag = true;
            Lesar_Enable = true;
            
            //this.GetComponentInParent<Lesar_Script>().Lesar_Distance = lesar_pos;
        }
        else if (other.gameObject.CompareTag("gimick_button"))
        {
            other.GetComponent<Lesar_Clear>().Clear();
            
            Lesar_Flag = true;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<Lesar_Script>().Lesar_Distance = 0.0f;

            Lesar_Flag = true;
            Lesar_Enable = true;
        }


    }

}
