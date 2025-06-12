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
    void OnButtonClick()
    {
        // ボタンがクリックされた時の処理
       
    }
    // Update is called once per frame
    void Update()
    {
       
    }

     void OnMouseEnter()
    {
        this.GetComponent<Text>().color =  Color.red;
        Debug.Log(this.name);
    }
     void OnMouseExit()
    {
        this.GetComponent<Text>().color = new Color(0,0,0);
        Debug.Log("b");
    }

//    public void switchon(DialogueOption[] options)
//    {
      

//        talk_checker = player.GetComponent<Talk_Checker>();

//        switch (swicth_num)
//            {
//                case 1:
//                    next_dialogue = 0;
//                    break;
//                case 2:
//                    next_dialogue = 1;
//                    break;
//                case 3:
//                    next_dialogue = 2;
//                    break;
//                case 4:
//                    next_dialogue = 3;
//                    break;

//                default:
//                    break;
//            }
    
//        Debug.Log("Switch On!!"+next_dialogue);
//        Debug.Log(talk_checker.talk_npc + "aaaaaaaa");
//        choice_flag = false;

//        // Do = talk_checker.talk_npc.GetComponent<DialogSentence>();
//        // scriptableObject = talk_checker.talk_npc.GetComponent<DialogText2>();
//        //talk_checker.talk_npc.dialogue_text = options[next_dialogue].Next_Dialogue;
//        Debug.Log("c3po");
//      // Do.Options[next_dialogue].Next_Dialogue = talk_checker.talk_npc.dialogue_text ;


//        //scriptableObject = Do.Next_Dialogue;

////#if UNITY_EDITOR
////        EditorUtility.SetDirty(talk_checker.talk_npc.dialogue_text); // scriptableObjectは書き換えたScriptableObject
////        AssetDatabase.SaveAssets();
////#endif
//    }

//    private void OnMouseDown()
//    {
//        choice_flag = true;
//    }

//    private void OnMouseUp()
//    {
//        choice_flag = false;
//    }
}
