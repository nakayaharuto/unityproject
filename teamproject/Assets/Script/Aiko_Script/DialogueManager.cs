using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Rendering.PostProcessing;
using UnityEditor.Rendering;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialogue_panel;
    public bool istalkable;

   private Queue<DialogSentence> sentences;
    
    [SerializeField] private Text npc_text;
    [SerializeField] private Text character_name;
    //private bool talk_flag = false;
    //private int index=0;
    //[SerializeField] private DialogText2 dialogText;
    private void Awake()
    {
        Debug.Log(instance);
        if (instance==null)
        {

            instance = this;
            Debug.Log(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<DialogSentence>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("a");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplaySentence();
        }
    }

    public void StartDialogue(NPC targetNPC)
    {
        if (istalkable == true)
        {


            //GameManager.instance.is_playable = false;
            Time.timeScale = 0.0f;


           


            sentences.Clear();

            foreach (DialogSentence sentence in targetNPC.dialogue_text.Paragraphs)
            {
                sentences.Enqueue(sentence);
            }
            //foreach(string sentence2 in targetNPC.dialogue_text.SpeakerName)
            //{
            //    sentences2.Enqueue(sentence2);
            //}

            dialogue_panel.SetActive(true);
           
            //UI_Sentence.text = targetNPC.dialogue_text.Paragraphs[0];
            DisplaySentence();
            istalkable = false;
        }
        //else
        //{
        //    DisplaySentence();
        //}

         
        
    }

    public void DisplaySentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        
        Debug.Log(sentences.Count);
        
        DialogSentence sentence = sentences.Dequeue();
        //string sentence2 = sentences2.Dequeue();

        npc_text.text = sentence.Content;
        character_name.text = sentence.TalkerName;

        //‘I‘ðŽˆ‚ª‚ ‚é‚È‚ç
        //if (sentence.Options.Length!=0)
        //{
        //    //StartCoroutine(DisplayOption(sentence.Options));
        //}
    }

    //IEnumerator DisplayOption(DialogueOption[] options)
    //{
    //    dialogue_panel.SetActive(false);
    //    //GameManager.instance.ChangeState(GameManager.PlayerState.choosiingDialogueOption);

    //    for (int i = 0; i < options.Length; i++)
    //    {
    //        dialogueOptionBox[i].SetActive(true);


            
    //    }


    //}

    public void EndDialogue()
    {
        //GameManager.instance.is_playable = true;
        Time.timeScale = 1.0f;
        Debug.Log("end");
        dialogue_panel.SetActive(false);
        istalkable = true;
    }

}
