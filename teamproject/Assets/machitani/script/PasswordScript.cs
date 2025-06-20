using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PasswordScript : MonoBehaviour
{
    private bool isNear;
    public GameObject text;
    public GameObject Password1;
    public GameObject Password2;
    public GameObject Password3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetActive(false);
        isNear=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")&&Password1.CompareTag("box"))
        {
            Debug.Log("aaa");
            text.SetActive(true);
        }
        if (Input.GetKeyDown("f") && Password2.CompareTag("Player"))
        {
            text.SetActive(true);
        }
        if (Input.GetKeyDown("f") && Password3.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            isNear=true; 
        }
    }
    void OnTriggerExit(Collider col)
    {
        isNear =false;
        text.SetActive(false);
    }
}
