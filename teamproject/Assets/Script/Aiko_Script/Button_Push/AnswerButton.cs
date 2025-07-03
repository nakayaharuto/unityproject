using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private bool true_flag = false;
    public GameObject[] color_buttons;
   public Cbutton_push[] CP;
    public HintMonitor HM;
    [SerializeField] private int order_answer_num=0;
    public int[] answer_num;
    RandomColor RC;
    public int[] true_num;
    public int test_num;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        RC = GameObject.Find("gimick4").GetComponent<RandomColor>();
        
            HM = GameObject.Find("HintMonitor").GetComponent<HintMonitor>();
        //while (HM.hint_text_num == 0)
        //{
        //    HM = GameObject.Find("HintMonitor").GetComponent<HintMonitor>();
        //}

        Debug.Log(HM.gameObject.name);
       
        switch (HM.hint_text_num)
        {
            case 1:
                
                order_answer_num = 13;
                answer_num = new int[13]{2,1,0,3,4,5,8,7,6,3,4,5,2 };

                break;
            case 2:
                order_answer_num = 9;
                answer_num = new int[9] { 0, 1, 2, 5, 4, 3, 6, 7, 8 };
                break;
            case 3:
                order_answer_num = 14;
                answer_num = new int[14] {0,3,6,0,1,2,5,8,3,4,5,6,7,8 };
                break;
            case 4:
                order_answer_num = 12;
                answer_num = new int[12] { 0, 1, 2, 0, 3, 6, 3, 4, 5, 6, 7, 8 };
                break;
            case 5:
                order_answer_num = 11;
                answer_num = new int[11] { 0,1,2,5,4,3,4,5,8,7,6};
                break;

        }

        for (int i = 0; i < order_answer_num; i++)
        {
            //true_num[answer_num[i]] = RC.rand_color_num[answer_num[i]];
            Debug.Log(RC.rand_color_num[answer_num[i]]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for(int i=0;i<3;i++)
        {
            CP[i]=color_buttons[i].GetComponent<Cbutton_push>();
            CP[i].push_num = 0;
            CP[i].push_text.text = "" + CP[i].push_num;
        }

    }

}
