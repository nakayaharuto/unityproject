using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Choice_Dialogue : MonoBehaviour
{
    int next_dialogue = 0;
    public int swicth_num;
    public bool choice_flag=false;
    public DialogSentence Do;
    private Talk_Checker talk_checker;
    [SerializeField] private DialogText2 scriptableObject;

    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void switchon(DialogueOption[] options)
    {
      

        talk_checker = player.GetComponent<Talk_Checker>();

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
        Debug.Log(talk_checker.talk_npc + "aaaaaaaa");
        choice_flag = false;

        // Do = talk_checker.talk_npc.GetComponent<DialogSentence>();
        // scriptableObject = talk_checker.talk_npc.GetComponent<DialogText2>();
        //talk_checker.talk_npc.dialogue_text = options[next_dialogue].Next_Dialogue;
        Debug.Log("c3po");
      // Do.Options[next_dialogue].Next_Dialogue = talk_checker.talk_npc.dialogue_text ;


        //scriptableObject = Do.Next_Dialogue;

//#if UNITY_EDITOR
//        EditorUtility.SetDirty(talk_checker.talk_npc.dialogue_text); // scriptableObjectÇÕèëÇ´ä∑Ç¶ÇΩScriptableObject
//        AssetDatabase.SaveAssets();
//#endif
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
