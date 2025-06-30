using UnityEngine;

public class Lesar_Flag_Script : MonoBehaviour
{
    public bool Lesar_Flag = true;
    public bool Lesar_Enable = true;
    public GameObject ColLesar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaa");
        //Lesar_Flag = false;
        if (collision.gameObject.CompareTag("Crane"))
        {
            Lesar_Flag = false;
            Debug.Log("bbbb");
        }
        else
        {
            Debug.Log("cccc");
           // Lesar_Flag = false;
        }
    }

    

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
        else
        {
            Debug.Log("ffff");
           Lesar_Flag = false;
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
       

        if (other.gameObject.CompareTag("Crane"))
        {
            other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Enable = false;
            //other.gameObject.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Flag = false;
           
        }

      
    }

}
