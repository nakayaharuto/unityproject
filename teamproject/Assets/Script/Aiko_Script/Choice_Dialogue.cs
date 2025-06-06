using UnityEngine;
using UnityEngine.UI;

public class Choice_Dialogue : MonoBehaviour
{
    int next_dialogue = 0;
    public int swicth_num;
    public bool choice_flag=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchon()
    { 
       
       
            switch (swicth_num)
            {
                case 1:
                    next_dialogue = 0;
                    break;
                case 2:
                    next_dialogue = 1;
                    break;
                case 3:
                    next_dialogue = 2;
                    break;
                case 4:
                    next_dialogue = 3;
                    break;

                default:
                    break;
            }
    
        Debug.Log("Switch On!!"+next_dialogue);
        choice_flag = false;
    }

    private void OnMouseDown()
    {
        choice_flag = true;
    }

    private void OnMouseUp()
    {
        choice_flag = false;
    }
}
