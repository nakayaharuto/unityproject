using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialogue_panel;
    public bool istalkable;

    Queue<string> sentences = new Queue<string>();
    [SerializeField] private Text npc_text;
    [SerializeField] private Text character_name;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(NPC targetNPC)
    {
        //GameManager.instance.is_playable = false;
        //Time.timeScale = 0.0f;

       

       

        sentences.Clear();

        foreach(string sentence in targetNPC.dialogue_text.Paragraphs)
        {
            sentences.Enqueue(sentence);
        }

        dialogue_panel.SetActive(true);

        //UI_Sentence.text = targetNPC.dialogue_text.Paragraphs[0];
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        npc_text.text = sentence;
    }

    public void EndDialogue()
    {
        //GameManager.instance.is_playable = true;
        //Time.timeScale = 1.0f;
        Debug.Log("end");
        dialogue_panel.SetActive(false);
    }

}
