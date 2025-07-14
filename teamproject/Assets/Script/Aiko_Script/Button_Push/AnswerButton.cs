using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(10)]
public class AnswerButton : MonoBehaviour
{
    [SerializeField] private bool true_flag = false;
    public GameObject[] color_buttons;
   public Cbutton_push[] CP;
    public HintMonitor HM;
    [SerializeField] public int order_answer_num=0;
    public int[] answer_num;
    RandomColor RC;
    public int[] true_num;
    public int[] click_button;
    public int[] button_color_num;
    [SerializeField] private int answer_count=0;
    public bool[] push_flag;

    public GameObject open_doors;
    public Animator animator;
    [SerializeField] private SoundManager SM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HM = GameObject.Find("HintMonitor").GetComponent<HintMonitor>();

        RC = GameObject.Find("gimick4").GetComponent<RandomColor>();
        
            
        //while (HM.hint_text_num == 0)
        //{
        //    HM = GameObject.Find("HintMonitor").GetComponent<HintMonitor>();
        //}

        Debug.Log("asdfg"+HM.gameObject.name);

        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        test();

        
    }

    // Update is called once per frame
    void Update()
    {
        //test();
    }

    private void OnMouseDown()
    {
        for(int i=0;i<3;i++)
        {
            CP[i]=color_buttons[i].GetComponent<Cbutton_push>();
            CP[i].push_num = 0;
            CP[i].push_text.text = "" + CP[i].push_num;
            CP[i].pm2 = 0;
        }

        for (int i = 0; i < order_answer_num; i++)
        {
            if (true_num[i] == button_color_num[i] && push_flag[i]==true)
            {
                
                answer_count++;
            }
            button_color_num[i] = 0;
            push_flag[i] = false;
        }
        
        if (answer_count==order_answer_num)
        {
            true_flag = true;
            this.GetComponent<BoxCollider>().enabled = false;
        }

        answer_count = 0;

        if (true_flag==true)
        {
            for (int i = 0; i < 3; i++)
            {
                CP[i] = color_buttons[i].GetComponent<Cbutton_push>();
                CP[i].GetComponent<Renderer>().material.color = Color.green;
                
            }
            animator = open_doors.GetComponentInChildren<Animator>();
            animator.SetBool("open", false);
            SM.Play(SoundManager.SoundType.correctans); //サウンドマネージャーを使用して効果音再生
            Debug.Log("yes");
        }
        else
        {
            SM.Play(SoundManager.SoundType.Incorrectans); //サウンドマネージャーを使用して効果音再生
            Debug.Log ("no");
        }

    }

    public void test()
    {
        switch (HM.hint_text_num)
        {
            case 1:

                order_answer_num = 13;
                answer_num = new int[13] { 2, 1, 0, 3, 4, 5, 8, 7, 6, 3, 4, 5, 2 };

                break;
            case 2:
                order_answer_num = 9;
                answer_num = new int[9] { 0, 1, 2, 5, 4, 3, 6, 7, 8 };
                break;
            case 3:
                order_answer_num = 14;
                answer_num = new int[14] { 0, 3, 6, 0, 1, 2, 5, 8, 3, 4, 5, 6, 7, 8 };
                break;
            case 4:
                order_answer_num = 12;
                answer_num = new int[12] { 0, 1, 2, 0, 3, 6, 3, 4, 5, 6, 7, 8 };
                break;
            case 5:
                order_answer_num = 11;
                answer_num = new int[11] { 0, 1, 2, 5, 4, 3, 4, 5, 8, 7, 6 };
                break;

        }

        //while(test_num!= order_answer_num)
        //{
        //    Debug.Log(RC.rand_color_num[answer_num[test_num]] + "axolotl" + test_num);
        //    Debug.Log("order_answer_num" + order_answer_num);
        //    true_num[test_num] = test_num;

        //    test_num++;
        //}

        true_num= new int[order_answer_num];
        click_button= new int[order_answer_num];
        button_color_num = new int[order_answer_num];
        push_flag = new bool[order_answer_num];

        for (int i = 0; i < order_answer_num; i++)
        {
            true_num[i] = 0;
            Debug.Log(RC.rand_color_num[answer_num[i]] + "axolotl" + i);
            Debug.Log("order_answer_num" + order_answer_num);
            true_num[i] = RC.rand_color_num[answer_num[i]];


        }

    }

}
