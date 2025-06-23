using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PasswordScript : MonoBehaviour
{
    private bool isNear;
    public GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")&&isNear)
        {
            text.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isNear = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isNear=false;
        text.SetActive(false);
    }

}
