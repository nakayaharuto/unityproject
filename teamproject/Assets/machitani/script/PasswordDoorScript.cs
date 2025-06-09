using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PasswordDoorScript : MonoBehaviour
{
    private bool isNear;
    private Animator animator;
    public InputField inputField;
    public GameObject fieldObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fieldObject.SetActive(false);
        isNear = false;
        animator=transform.parent.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("f")&&isNear)
        {
            fieldObject.SetActive(true);
        }
    }

    public void InputPass()
    {
        if(inputField.text=="1234")
        {
            animator.SetBool("open",!animator.GetBool("open"));
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            isNear = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        isNear=false;
        fieldObject.SetActive(false);
    }
}
