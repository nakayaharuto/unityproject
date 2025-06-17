using UnityEngine;

public class Operate_Clane_Button : MonoBehaviour
{
    [Header("0:右、1:左、2:前、3:後ろ、4:下")]
    public int dilection_num;
    public int move_limit_x;
    public int move_limit_y;
    public int move_limit_z;
    public GameObject Crane;
    public bool button_flag = false;
    public int button_num=-1;

    public GameObject[] buttons;

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
                case 0://右
                    if (Crane.transform.position.x >= -100)
                    {
                        Crane.transform.Translate(-Time.deltaTime, 0, 0);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    break;
                case 1://左
                    if (Crane.transform.position.x <= 100)
                    {
                        Crane.transform.Translate(Time.deltaTime, 0, 0);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    break;
                case 2://前
                    if (Crane.transform.position.z <= 100)
                    {
                        Crane.transform.Translate(0, 0, Time.deltaTime);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    break;
                case 3://後ろ
                    if (Crane.transform.position.z >= -100)
                    {
                        Crane.transform.Translate(0, 0, -Time.deltaTime);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    break;
                case 4:
                    if (Crane.transform.position.y >= 0)
                    {
                        Crane.transform.Translate(0, -Time.deltaTime, 0);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    break;

                default: 
                    break;
            }


        }


    }

    //public void ButtonClick()
    //{
    //    Debug.Log("ghjkl");
    //    button_flag = true;

    //}

    private void OnMouseDown()
    {
        for (int i = 0; i < 4; i++)
        {
           
                Operate_Clane_Button OCB = buttons[i].GetComponent<Operate_Clane_Button>();
                OCB.button_flag = false;
                if (OCB.button_num==1)
                {
                    OCB.button_num = -OCB.button_num;
                }
               
                Debug.Log(OCB.name);
           
        }

        switch (button_num)
        {
            case -1:
                button_flag = true;
                break;
            case 1:
                button_flag = false;
                break;
        }
        Debug.Log(button_flag);
        button_num = -button_num;
        Debug.Log(button_num);
    }

}
