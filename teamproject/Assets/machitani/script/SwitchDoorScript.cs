using UnityEngine;
using System.Collections;

public class SwitchDoorScript : MonoBehaviour
{
    public bool isOpen;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOpen = false;
        animator=transform.parent.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            animator.SetBool("open",false); 
        }
        else if(!isOpen)
        {
            animator.SetBool("open", true);
        }
    }

}
