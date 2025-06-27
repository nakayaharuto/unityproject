using UnityEngine;

public class Lesar_On_Off : MonoBehaviour
{
    public bool button_flag=false;
    //public int switch_on_off=0;
    public GameObject first_lesar_machine;
   
    public Lesar_Script LS;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LS = first_lesar_machine.GetComponent<Lesar_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (button_flag==false)
        {
            button_flag = true;
            LS.Fire_Flag=true;
        }
        else
        {
            foreach (GameObject LS in GameObject.FindGameObjectsWithTag("Crane"))
            {
                Debug.Log(LS.name);
                LS.GetComponent<Lesar_Script>().Fire_Flag = false;
                LS.GetComponent<Lesar_Script>().LFS.Lesar_Enable = false;
            }

            LS.Fire_Flag = false;
            LS.LFS.Lesar_Flag = true;
            button_flag =false;
        }

    }

}
