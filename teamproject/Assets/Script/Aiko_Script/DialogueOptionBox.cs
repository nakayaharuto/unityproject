using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueOptionBox : MonoBehaviour//,IPointerClickHandler
{
    private Talk_Checker talk_checker;

    [SerializeField]
    public DialogueOption dialogueOption;

    [SerializeField]
    public Text optionText;

    public int option_order_num;

    

    public Choice choice;

    public void Start()
    {
        choice=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Choice>();
    }

    public void Test()
    {
        talk_checker = GameObject.FindGameObjectWithTag("Player").GetComponent<Talk_Checker>();
        talk_checker.talk_npc.dialogue_text = dialogueOption.Next_Dialogue;
        DialogueManager.instance.EndDialogue();
        DialogueManager.instance.StartDialogue(dialogueOption.Next_Dialogue);
        Debug.Log("bisyagatuku");
        choice.j = 0;
        choice.Choose();
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    talk_checker = GameObject.FindGameObjectWithTag("Player").GetComponent<Talk_Checker>();
    //    talk_checker.talk_npc.dialogue_text = dialogueOption.Next_Dialogue;
    //    DialogueManager.instance.EndDialogue();
    //    DialogueManager.instance.StartDialogue(dialogueOption.Next_Dialogue);
    //    Debug.Log("bisyagatuku");

    //}

    //private void OnMouseDown()
    //{
    //    Test();
    //    Debug.Log("bisyagatuku");
    //}


    public void UpdateUI()
    {
        optionText.text = dialogueOption.optionText;
        Debug.Log("korosuke)");

    }

    public void Update()
    {
        

        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (j < 4)
        //    {
        //        j++;


        //    }
        //    else
        //    {
        //        j = 0;
        //    }

        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (j==option_order_num)
        //        {
        //            dialogue_option_box[j].GetComponent<Text>().color = Color.red;
        //        }
        //    }

        //}
    }

}
