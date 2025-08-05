using UnityEngine;

public class Rot_Floor : MonoBehaviour
{
    [SerializeField] private Move_Insect MI;
    [SerializeField] private bool plus_mainas;
    [SerializeField] private Renderer RS;
   
    [SerializeField] private int test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        test = 200;

        RS= GetComponent<Renderer>();

        if (plus_mainas==true)
        {
            RS.material.color = Color.blue;
        }
        else
        {
            RS.material.color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<BoxCollider>().enabled==false)
        {
            test--;
        }

        if (test < 0) 
        {
        this.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscortTarget"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            MI = other.GetComponent<Move_Insect>();

            other.transform.position=this.transform.position;

            test = 200;

            if (plus_mainas==true)
            {
                MI.rot_num++;
                other.transform.localEulerAngles = new Vector3(0f, 90f*MI.rot_num*MI.rot_plus_mainas, 0f);
                
            }
            else 
            {
                MI.rot_num--;
                other.transform.localEulerAngles = new Vector3(0f, 90f * MI.rot_num*MI.rot_plus_mainas, 0f);
                
            }

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EscortTarget"))
        {

          
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }


}
