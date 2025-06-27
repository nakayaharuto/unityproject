using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PasswordDoorScript : MonoBehaviour
{
    private bool isNear;
    private Animator animator;
    public InputField inputField;
    public GameObject fieldObject;
    //public GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //text.SetActive(false);
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
            //マウスポインタを表示
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void InputPass()
    {
        if(inputField.text=="123")
        {
            animator.SetBool("open",!animator.GetBool("open"));
            fieldObject.SetActive(false);
            //マウスポインタを表示
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
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
