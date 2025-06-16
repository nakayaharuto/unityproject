using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueOptionBox : MonoBehaviour,IPointerClickHandler
{
    private Talk_Checker talk_checker;

    [SerializeField]
    public DialogueOption dialogueOption;

    [SerializeField]
    public Text optionText;

    

    public void OnPointerClick(PointerEventData eventData)
    {
        talk_checker = GameObject.Find("Player").GetComponent<Talk_Checker>();
        talk_checker.talk_npc.dialogue_text = dialogueOption.Next_Dialogue;
        DialogueManager.instance.EndDialogue();
        DialogueManager.instance.StartDialogue(dialogueOption.Next_Dialogue);
        Debug.Log("bisyagatuku");

    }

    


    public void UpdateUI()
    {
        optionText.text = dialogueOption.optionText;
        Debug.Log("korosuke)");

    }

}
