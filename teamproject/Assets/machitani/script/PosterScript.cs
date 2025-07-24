using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosterScript : MonoBehaviour
{
    private bool isNear;
    public GameObject text;
    private int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetActive(false);
        isNear = false;
         i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")&&isNear)
        {
            text.SetActive(true);
        }
        else if (Input.GetKeyDown("w")|| Input.GetKeyDown("s")|| Input.GetKeyDown("d")|| Input.GetKeyDown("a"))
        {
            text.SetActive(false);
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
