using UnityEngine;

public class Lesar_Script : MonoBehaviour
{
    public GameObject Lesar_Ray;
    public float Lesar_Distance = 0.0f;
   
    public Lesar_Flag_Script LFS;

    public bool Fire_Flag = false;
    [SerializeField] private int rot_num;

    [Header("0â°âÒì]ÅA1â∫å¸Ç´âÒì]ÅA2è„å¸Ç´âÒì]")]public int direction_num;

    private bool reversal_flag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       LFS=this.GetComponentInChildren<Lesar_Flag_Script>();
        LFS.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log(LFS.Lesar_Flag);
    }

    // Update is called once per frame
    void Update()
    {
        if (LFS.Lesar_Flag==true&&Fire_Flag==true||LFS.Lesar_Flag==true&&LFS.Lesar_Enable==true)
        {
            Lesar_Distance+=2f;
            Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance);
           // Lesar_Ray.transform.position=new Vector3(this.transform.position.x, this.transform.position.y, ((this.transform.position.z) - Lesar_Distance*0.3f) - 0.7f);
        }
        else if (LFS.Lesar_Enable == false && Fire_Flag==false)
        {
            Lesar_Distance = 0f;
            Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance);
        }


        
    }

    private void OnMouseDown()
    {

        Lesar_Distance = 0f;
        LFS.Lesar_Flag = true;

        switch (direction_num)
        {
            case 0:
                if (rot_num < 3)
                {
                    rot_num++;
                }
                else
                {
                    rot_num = 0;
                }
                this.gameObject.transform.eulerAngles = new Vector3(0f, 90f * rot_num, 0f);
                break;
            case 1://â∫
                if (rot_num == 2)
                {
                    reversal_flag = true;
                }
                else if (rot_num == 0)
                {
                    reversal_flag = false; ;
                }

                if (reversal_flag == false)
                {
                    rot_num++;
                }
                else if (reversal_flag == true)
                {
                    rot_num--;
                }

                this.gameObject.transform.eulerAngles = new Vector3(90f * -rot_num, 0f, 0f);

                break;
            case 2://è„

                if (rot_num == 2)
                {
                    reversal_flag = true;
                }else if (rot_num==0)
                {
                    reversal_flag = false; ;
                }

                if (reversal_flag==false)
                {
                    rot_num++;
                }
                else if(reversal_flag==true)
                {
                    rot_num--;
                }

                this.gameObject.transform.eulerAngles = new Vector3(90f * rot_num, 0f, 0f);

                break;

        }
        

        


        if (LFS.ColLesar.CompareTag("Crane"))
        {
            LFS.ColLesar.GetComponentInChildren<Lesar_Flag_Script>().Lesar_Flag = false;
        }

        
        //LFS.ColLesar.GetComponent<Lesar_Script>().Lesar_Distance = 0f;
        //LFS.ColLesar.GetComponent<Lesar_Script>().Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance*0);

        Debug.Log(LFS.ColLesar.name);

        

        Debug.Log(Fire_Flag);

    }


}
