using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;




    [CreateAssetMenu(menuName = "Dialogue/new Dialogue Container")]
    public class DialogText2 : ScriptableObject
    {
        //[SerializeField, Header("キャラ名"), TextArea]
        // private DialogSentence[] speaker_name;

        [SerializeField, Header("会話文")]
        private DialogSentence[] paragraphs;

        public DialogSentence[] Paragraphs => paragraphs;
    //public DialogSentence[] SpeakerName => speaker_name;

    //public DialogText2 end_text;

    [SerializeField] private EndText endtext;

    public EndText Endtext=>endtext;

    }

    [System.Serializable]
    public class DialogSentence
    {
        [SerializeField, Header("キャラ名"), TextArea]
        public string TalkerName;

        [SerializeField, Header("会話文"), TextArea]
        public string Content;

        //選択肢の表示に使う
        public DialogueOption[] Options;

        //public bool SkipFlag;

    }


    [System.Serializable]
    public class DialogueOption
    {
        public string optionText;

        //選択肢を選んだ場合に表示される会話テキスト
        public DialogText2 Next_Dialogue;
    }

[System.Serializable]
public class EndText
{
    public DialogText2 End_Text;
}

//[System.Serializable]
//public class EndDialogue
//{
//    public DialogText2 EndText;
//}
