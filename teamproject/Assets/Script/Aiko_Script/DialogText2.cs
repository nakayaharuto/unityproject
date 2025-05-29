using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue/new Dialogue Container")]
public class DialogText2 : ScriptableObject
{
    public string speakerName;

    [SerializeField,Header("会話文"), TextArea(5, 10)]
    private string[] paragraphs;

    public string[] Paragraphs => paragraphs;
    //選択肢の表示に使う
    //public DialogueOption[] options;
}

public class DialogueOption
{
    public string optionText;

}