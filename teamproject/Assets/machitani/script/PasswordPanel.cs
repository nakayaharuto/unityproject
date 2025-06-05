using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PasswordPanel : MonoBehaviour
{
    public string correctPassword = "1234";//パスワード
    public Text displayText;
    public GameObject passwordPanel;
    private bool isNear;
    private Animator animator;
    private string inputPassword = " ";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isNear = false;
        animator=transform.parent.GetComponent<Animator>();
        passwordPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")&&isNear)
        {
            passwordPanel.SetActive(true);
        }
    }
     void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            isNear=true;
        }
    }
     void OnTriggerExit(Collider col)
    {
       if(col.tag=="Player")
        {
            isNear=false;
            passwordPanel.SetActive(false);
        }
    }
    public void AppendNumber(string number)
    {
        inputPassword += number;
        displayText.text = inputPassword;
    }
    public void CheckPassword()
    {
        if(inputPassword==correctPassword)
        {
            animator.SetBool("open", !animator.GetBool("open"));
        }
        inputPassword = " ";
        displayText.text = inputPassword;
    }
    
}
