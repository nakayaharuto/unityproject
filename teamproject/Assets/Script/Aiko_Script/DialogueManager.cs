using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Rendering.PostProcessing;
using UnityEditor.Rendering;
using Unity.VisualScripting;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialogue_panel;
    public bool istalkable;
    public GameObject[] dialogue_option_box;
    public GameObject dialogue_option_panel;
    private Queue<DialogSentence> sentences;
    //private Queue<DialogueOption>[] Osentence2;
    private Talk_Checker talk_checker;
    private NPC npc;
    private DialogSentence sentence1;
    Choice_Dialogue choice_Dialogue;
    [SerializeField] private Text npc_text;
    [SerializeField] private Text character_name;
    [SerializeField] private Text[] optin_text;
    //private bool talk_flag = false;
    //private int index=0;
    //[SerializeField] private DialogText2 dialogText;
    private void Awake()
    {
        Debug.Log(instance);
        if (instance == null)
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
        //Osentence2 = new Queue<DialogueOption>();
       
        
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
            
            

            foreach(DialogSentence sentence in targetNPC.dialogue_text.Paragraphs)
            {
                sentences.Enqueue(sentence);
            }
            

            dialogue_panel.SetActive(true);

            //UI_Sentence.text = targetNPC.dialogue_text.Paragraphs[0];
            DisplaySentence();
            istalkable = false;
        }
        



    }

    public void DisplaySentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Debug.Log(sentences.Count);
       
        DialogSentence sentence = sentences.Dequeue();
        //string sentence2 = sentences2.Dequeue();

        

        npc_text.text = sentence.Content;
        character_name.text = sentence.TalkerName;
        Debug.Log("option:"+sentence.Options.Length);
        // ‘I‘ðŽˆ‚ª‚ ‚é‚È‚ç
        if (sentence.Options.Length != 0)
        {
            StartCoroutine(DisplayOption(sentence.Options));
            //DisplayOption(sentence.Options);
           
        }
        else
        {
            dialogue_option_panel.SetActive(false);
            dialogue_panel.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                optin_text[i].text = "";
                dialogue_option_box[i].SetActive(false);
            }
        }
    }
    
    IEnumerator DisplayOption(DialogueOption[] options)
    {
        int j =0;

        //DialogSentence sentence= sentences.Dequeue();
        // DialogueOption ooo = Osentence2.Dequeue();
        //GameManager.instance.ChangeState(GameManager.PlayerState.choosing);

        // DialogSentence sssssentence2;
        for (int i = 0; i < options.Length; i++)
        {
            Debug.Log(options.Length + "+optionLength");

            dialogue_option_box[i].SetActive(true);
            optin_text[i].text = options[i].optionText;
            
          
            
            //SelectOptions select_options = dialogue_option_box[i].GetComponent<SelectOptions>();

            Debug.Log(dialogue_option_box[i] + "optionbox");


            j = i;
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            sentences.Clear();

            //choice_Dialogue.switchon(options);
            Debug.Log("ccccc");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue_panel.SetActive(false);
           
            yield return new WaitForSecondsRealtime(0.1f);
            dialogue_option_panel.SetActive(true);
            
        }

        
        //yield return new WaitForSeconds(1f);
    } 

    public void EndDialogue()
    {
        //GameManager.instance.is_playable = true;
        Time.timeScale = 1.0f;
        Debug.Log("end");
        dialogue_panel.SetActive(false);
        istalkable = true;
    }

    public void ChoiceOption()
    {
        talk_checker = GameObject.Find("Player").GetComponent<Talk_Checker>();
        //sentence1 = talk_checker.talk_npc.dialogue_text.GetComponent<DialogText2>().GetComponent<DialogSentence>();
        //sentence1 = sentences.Dequeue().Options[0].Next_Dialogue;

        //Debug.Log(sentence1.Options[0].optionText);
        Debug.Log(sentence1);

        talk_checker.talk_npc.dialogue_text = sentence1.Options[0].Next_Dialogue;
        dialogue_option_panel.SetActive(false);
        StartDialogue(talk_checker.talk_npc);
        //npc.dialogue_text = null;
        Debug.Log(talk_checker.talk_npc);
    }

}
