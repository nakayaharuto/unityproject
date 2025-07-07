using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI使うときに必要
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
   public Button D_button;
    Text text;

    public int j = 0;
    public int k = 0;

    public GameObject[] buttons; 

    void Start()
    {
        D_button = GameObject.Find("Bored2/Canvas/OptionPanel/dialogue_option1").GetComponent<Button>();
        text = GameObject.Find("Bored2/Canvas/OptionPanel/dialogue_option1").GetComponent<Text>();
        //ボタンが選択された状態になる
        D_button.Select();
        text.color = Color.red;
    }

    public void ConfirmButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].activeSelf)
            {
                k++;
            }

        }
    }
    private void Update()
    {
        if (buttons[0].activeSelf==true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                k = 0;
                ConfirmButtons();
                if (j < k - 1)
                {
                    j++;
                }
                else
                {
                    j = 0;
                }
                Choose();

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                k = 0;
                ConfirmButtons();
                if (j > 0)
                {
                    j--;
                }
                else
                {
                    j = k - 1;
                }
                Choose();
            }
        }

        

        }

    public void Choose()
    {
        for (int i = 0; i <k; i++)
        {
            
            buttons[i].GetComponent<Text>().color = Color.black;

            
        }

            buttons[j].GetComponent<Button>().Select();
            buttons[j].GetComponent<Text>().color = Color.red;
           
        Debug.Log(j);
    }

}
