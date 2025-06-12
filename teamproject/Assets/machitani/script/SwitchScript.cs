using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public SwitchDoorScript SwitchDoorScript;
    private bool isNear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear)
        {
            SwitchDoorScript.isOpen = true;
        }
        else
        {
            SwitchDoorScript.isOpen = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player"||col.tag=="box")
        {
            isNear = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player"||col.tag=="box")
        {
            isNear = false;
        }
    }

}
