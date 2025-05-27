using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue/new Dialogue Container")]
public class DialogText2 : ScriptableObject
{
    public string speakerName;

    [TextArea(5, 10)]
    public string[] paragraphs;
    //‘I‘ðŽˆ‚Ì•\Ž¦‚ÉŽg‚¤
    public DialogueOption[] options;
}

public class DialogueOption
{
    public string optionText;

}