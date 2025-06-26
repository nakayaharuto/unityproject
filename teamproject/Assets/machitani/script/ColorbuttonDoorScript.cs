using UnityEngine;

public class ColorbuttonDoorScript : MonoBehaviour
{
    public SwitchDoorScript SwitchDoorScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
        {
            SwitchDoorScript.isOpen = true;
        }
    }
}
