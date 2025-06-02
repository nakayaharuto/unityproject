using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class DialogSentence
{
    [SerializeField, Header("キャラ名"), TextArea]
    public string TalkerName;

    [SerializeField, Header("会話文"), TextArea]
    public string Content;
}


[CreateAssetMenu(menuName ="Dialogue/new Dialogue Container")]
public class DialogText2 : ScriptableObject
{
    //[SerializeField, Header("キャラ名"), TextArea]
   // private DialogSentence[] speaker_name;

    [SerializeField,Header("会話文")]
    private DialogSentence[] paragraphs;

    public DialogSentence[] Paragraphs=>paragraphs;
    //public DialogSentence[] SpeakerName => speaker_name;

    //選択肢の表示に使う
    public DialogueOption[] options;
}

[System.Serializable]
public class DialogueOption
{
    public string optionText;

    //選択肢を選んだ場合に表示される会話テキスト
    public DialogText2 Next_Dialogue;
}