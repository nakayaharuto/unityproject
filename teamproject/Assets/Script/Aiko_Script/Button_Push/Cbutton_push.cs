using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(11)]
public class Cbutton_push : MonoBehaviour
{
    [SerializeField]public int push_num = 0;
    public Text push_text;
    [SerializeField] private int button_color;
    AnswerButton AB;
    
    [SerializeField] public int pm2=0;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        push_text.text = "" + 0;

        switch(button_color)
        {
            case 0:
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                this.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                this.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
        AB = GameObject.Find("AnswerButton_v1").GetComponent<AnswerButton>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        //foreach (GameObject button in GameObject.FindGameObjectsWithTag("gimick_button"))
        //{
        //    button.GetComponent<Cbutton_push>().pm3 = button.GetComponent<Cbutton_push>().pm1;
        //    

        //    Debug.Log(button.name);
        //}



        AB.button_color_num[pm2] = button_color;
        AB.push_flag[pm2] = true;
        for (int i = 0; i < AB.color_buttons.Length; i++)
        {
            AB.color_buttons[i].GetComponent<Cbutton_push>().pm2+=1;
            
        }

        if (pm2==AB.order_answer_num)
        {
            for (int i = 0; i < AB.color_buttons.Length; i++)
            {
                AB.color_buttons[i].GetComponent<Cbutton_push>().pm2 -= 1;
            }
        }

        //foreach (GameObject button in GameObject.FindGameObjectsWithTag("gimick_button"))
        //{

        //    pm1 = pm2;
        //    pm2 = pm1;
        //}
        push_num++;
        push_text.text = "" + push_num;
    }
}
