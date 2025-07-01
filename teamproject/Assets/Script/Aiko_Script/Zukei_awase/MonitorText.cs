using UnityEngine;
using UnityEngine.UI;


public class MonitorText : MonoBehaviour
{
    //public GameObject Monitor;
    public Text moni_text;
    [SerializeField]private int[] appear_num;
    ShapeRotate SR;
    NumCheckiAnswer NCA;
    public GameObject[] rl_buttons;
    [SerializeField]private int button_num=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NCA=GameObject.FindGameObjectWithTag("Respawn").GetComponent<NumCheckiAnswer>();

        for (int i = 0; i < 4; i++)
        {
            SR = NCA.rotate_objects[i].GetComponent<ShapeRotate>();



            Debug.Log("bbbb" + SR.name);
            Debug.Log(SR.random_num);
            appear_num[i] = SR.random_num;
            Debug.Log("aaaaaa" + appear_num[i]);


        }


    }

    private void OnMouseDown()
    {
       

        }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == rl_buttons[0])
                {
                    if (button_num>0)
                    {
                        button_num--;
                    }
                    

                    Debug.Log("left");
                }
                else if (hit.collider.gameObject == rl_buttons[1])
                {

                    if (button_num < 3)
                    {
                        button_num++;
                    }
                    Debug.Log("right");
                }
                TextAppear();
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        
    }

    public void TextAppear()
    {
        
        switch(button_num)
        {
            case 0:
                moni_text.text = "‘¾—z" + appear_num[0];
                break;
            case 1:
                moni_text.text = "ŒŽ" + appear_num[1];
                break;
            case 2:
                moni_text.text = "ƒ~ƒTƒCƒ‹" + appear_num[2];
                break;
            case 3:
                moni_text.text = "‰J" + appear_num[3];
                break;
        }

    }


}
