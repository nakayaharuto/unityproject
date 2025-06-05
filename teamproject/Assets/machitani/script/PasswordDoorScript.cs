using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PasswordDoorScript : MonoBehaviour
{
    //ドアエリアに入ってるかどうか
    private bool isNear;
    //ドアアニメーター
    private Animator animator;
    public GameObject fieldObject;
    public InputField inputField;
    public Text displayText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fieldObject.SetActive(false);
        isNear = false;
        animator=transform.parent.GetComponent<Animator>();
        //inputField=GetComponent<InputField>();
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
            animator.SetBool("open", !animator.GetBool("open"));
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isNear = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isNear = false;
            fieldObject.SetActive(false); 
        }
    }

    public void DisplayText()
    {
        displayText.GetComponent<Text>().text = inputField.text;    
    }
}
