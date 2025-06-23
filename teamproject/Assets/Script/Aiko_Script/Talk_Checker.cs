using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Talk_Checker : MonoBehaviour
{
    public NPC talk_npc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPC target = collision.gameObject.GetComponent<NPC>();

            talk_npc = target;

            target.talk_icon.SetActive(true);

            DialogueManager.instance.istalkable = true;
            Debug.Log(talk_npc);
           
               // DialogueManager.instance.StartDialogue(talk_npc);
            
        }


    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPC target = collision.gameObject.GetComponent<NPC>();

         

            target.talk_icon.SetActive(false);

            if (talk_npc==target)
            {
                talk_npc = null;
            }

            DialogueManager.instance.istalkable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
