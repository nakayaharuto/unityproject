using UnityEngine;

public class Lesar_On_Off : MonoBehaviour
{
    public bool button_flag=false;
    public int switch_on_off=0;
    public GameObject first_lesar_machine;
   
    public Lesar_Script LS;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LS = first_lesar_machine.GetComponent<Lesar_Script>();
    }

    private void OnMouseDown()
    {
        switch(switch_on_off)
        {
            case 0:
                button_flag= true;
                switch_on_off = 1;
               // LS.Fire_Flag = true;
                break;
            case 1:
                button_flag = false;
                switch_on_off = 0;
                //LS.Fire_Flag= false;
                break;

        }

    }

}
