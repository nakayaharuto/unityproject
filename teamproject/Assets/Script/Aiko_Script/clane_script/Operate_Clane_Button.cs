using UnityEngine;

public class Operate_Clane_Button : MonoBehaviour
{
    [Header("0:右、1:左、2:前、3:後ろ、4:下、5:投下")]
    public int dilection_num;
    [Header("x軸、1は左の-へ、2は右の+へ")]
    public float move_limit_x;
    [Header("y軸")]
    public float move_limit_y;
    [Header("z軸、3は前の+へ、4は後ろの-へ")]
    public float move_limit_z;
    public GameObject Crane;
    public bool button_flag = false;
    public int button_num=-1;

    public Move_Clane MC;
    //[SerializeField] private bool hit = false;

    public GameObject[] buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MC = Crane.GetComponent<Move_Clane>();
        this.GetComponent<Renderer>().material.color = Color.green;
    }



    // Update is called once per frame
    void Update()
    {
        if (button_flag)
        {
            switch(dilection_num)
            {
                case 0://右
                    if (Crane.transform.position.x <= move_limit_x)
                    {
                        Crane.transform.Translate(Time.deltaTime, 0, 0);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    else
                    {
                        this.button_flag = false;
                        this.button_num = -1;
                        this.GetComponent<Renderer>().material.color = Color.green;
                    }
                    break;
                case 1://左
                    if (Crane.transform.position.x >= move_limit_x)
                    {
                        Crane.transform.Translate(-Time.deltaTime, 0, 0);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    else
                    {
                        this.button_flag = false;
                        this.button_num = -1;
                        this.GetComponent<Renderer>().material.color = Color.green;
                    }
                    break;
                case 2://前
                    if (Crane.transform.position.z <= move_limit_z)
                    {
                        Crane.transform.Translate(0, 0, Time.deltaTime);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    else
                    {
                        this.button_flag = false;
                        this.button_num = -1;
                        this.GetComponent<Renderer>().material.color = Color.green;
                    }
                    break;
                case 3://後ろ
                    if (Crane.transform.position.z >= move_limit_z)
                    {
                        Crane.transform.Translate(0, 0, -Time.deltaTime);
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    else
                    {
                        this.button_flag = false;
                        this.button_num = -1;
                        this.GetComponent<Renderer>().material.color = Color.green;
                    }
                    break;
                case 4://下
                    if (MC.hit == false)
                    {
                        Crane.transform.Translate(0, -Time.deltaTime, 0);
                        this.GetComponent<BoxCollider>().enabled = false;

                        for (int i = 0; i < 5; i++)
                        {
                            buttons[i].GetComponent<BoxCollider>().enabled = false;
                            buttons[i].GetComponent<Renderer>().material.color = Color.grey;
                        }

                        //buttons[4].GetComponent<BoxCollider>().enabled = false;
                        //Crane.transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Sin(Time.time) * 4);
                    }
                    else
                    {
                        if (Crane.transform.position.y <= move_limit_y)
                        {
                            Crane.transform.Translate(0, Time.deltaTime, 0);
                            this.GetComponent<BoxCollider>().enabled = false;
                           
                           
                        }
                        else
                        {
                            MC.hit = false;
                            this.button_flag = false;
                            this.button_num = -1;
                            this.GetComponent<Renderer>().material.color = Color.green;
                            this.GetComponent<BoxCollider>().enabled = true;
                            for (int i = 0; i < 5; i++)
                            {
                                buttons[i].GetComponent<BoxCollider>().enabled = true;
                                buttons[i].GetComponent<Renderer>().material.color = Color.green;
                            }
                        }

                    }

                        break;
                case 5://投下
                    if (MC.item_hit==true)
                    {
                        MC.item_hit = false;
                        MC.get_item.transform.position = new Vector3(Crane.transform.position.x, Crane.transform.position.y-0.7f, Crane.transform.position.z);
                        MC.get_item.GetComponent<Collider>().enabled = true;
                        MC.get_item.GetComponent<Rigidbody>().useGravity = true;

                    }
                    else
                    {
                        this.button_flag = false;
                        this.button_num = -1;
                        this.GetComponent<Renderer>().material.color = Color.green;
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
            OCB.GetComponent<Renderer>().material.color = Color.green;
            OCB.GetComponent<BoxCollider>().enabled = true;
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
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                button_flag = false;
                this.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
        Debug.Log(button_flag);
        button_num = -button_num;
        Debug.Log(button_num);
    }

}
