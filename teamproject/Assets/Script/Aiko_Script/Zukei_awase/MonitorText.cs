using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(5)]
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
       appear_num = new int[4];

        NCA=GameObject.Find("Num_Check_Answer").GetComponent<NumCheckiAnswer>();

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
                moni_text.text = "‘¾—z‚©‚çŒ©‚Ä" + appear_num[0]+"ŒÂ–Ú‚Ì˜f¯‚ª\n‰äX‚Ì˜f¯‚¾B";
                break;
            case 1:
                moni_text.text = "ŒŽ‚Ì–ž‚¿Œ‡‚¯‚Í‚¨‚¨‚æ‚»" + appear_num[1]+"“úŽüŠú‚¾B";
                break;
            case 2:
                moni_text.text = "ƒ~ƒTƒCƒ‹‚ª" + appear_num[2]+"“ú‚ÌŠÔA~‚è’‚¢‚¾B";
                break;
            case 3:
                moni_text.text = "ÅŒã‚É‰J‚ª~‚Á‚½‚Ì‚Í‚¢‚Â‚¾‚Á‚½‚©B\n" +"‚¨‚¨‚æ‚»"+ appear_num[3]+"”N‘O‚¾‚Á‚½‚©B";
                break;
        }

    }


}
