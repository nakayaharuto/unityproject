using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Text_Controll_Script : MonoBehaviour
{
    //[SerializeField] private Text messages;
    [SerializeField] private DialogText2 dialogText;
    [SerializeField] private GameObject Dialog_Place;
    [SerializeField] private Text dialogue_textComponent;
    [SerializeField] private Text speaker_name_text;
    //public string[] lines;

    private int index=0;
    bool isTyping;

    private Coroutine dialogueCoroutine;

   // public float textspeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            displayDialogueText();

            /*if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }*/
        }
    }

    public void displayDialogueText()
    {
        if (!Dialog_Place.activeSelf)
        {
            Dialog_Place.SetActive(true);
        }

        speaker_name_text.text = dialogText.speakerName;
        if (dialogText.paragraphs.Length>index)
        {
            if (!isTyping)
            {
                dialogueCoroutine = StartCoroutine(TypeDialogueText(dialogText.paragraphs[index]));
                //dialogue_textComponent.text = dialogText.paragraphs[index];
            }
            else
            {
                stopTyping();
            }
        }
        else
        {
            speaker_name_text.text = "";
            dialogue_textComponent.text = "";
            Dialog_Place.SetActive(false);
        }
        
    }

    private IEnumerator TypeDialogueText(string paragraph)
    {
        string displayText = "";
        isTyping = true;
       // int color_index = 0;
        foreach(char c in paragraph)
        {
            //color_index++;
            //dialogue_textComponent.text = paragraph;
            displayText = displayText + c;
            // displayText = dialogue_textComponent.text.Insert(color_index, "<color=#00000000>"); ;
            dialogue_textComponent.text = displayText;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
        index++;
    }

    private void stopTyping()
    {
        StopCoroutine(dialogueCoroutine);

        dialogue_textComponent.text = dialogText.paragraphs[index];
        isTyping = false;
        index++;
    }

    /*void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed); 
        }

    }

    void NextLine()
    {
        if(index<lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Dialog_Place.SetActive(false);
        }
    }*/

}
