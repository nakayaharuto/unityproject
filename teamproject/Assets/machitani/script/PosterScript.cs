using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosterScript : MonoBehaviour
{
    private bool isNear;
    public GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     text.SetActive(false);
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
    void OnTriggerExit(Collider col)
    {
        isNear = false;
        text.SetActive(false);
    }
}
