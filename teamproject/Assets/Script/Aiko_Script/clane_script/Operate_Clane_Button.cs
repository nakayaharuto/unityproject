using UnityEngine;

public class Operate_Clane_Button : MonoBehaviour
{
    public int dilection_num;
    public int move_limit;
    public GameObject Crane;
    public bool button_flag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (button_flag)
        {
            switch(dilection_num)
            {
                case 0:
                    if (Crane.transform.position.z <= 6.1)
                    {
                        Crane.transform.Translate(0, 0, Time.deltaTime);
                    }
                    break;

                default: 
                    break;
            }


        }


    }

    public void ButtonClick()
    {
        Debug.Log("ghjkl");
        button_flag = true;

    }
}
