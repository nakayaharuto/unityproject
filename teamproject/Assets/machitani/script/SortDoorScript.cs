using UnityEngine;

public class SortDoorScript : MonoBehaviour
{
    public SwitchDoorScript SwitchDoorScript;
    public GameObject Judge1;
    public GameObject Judge2;
    public GameObject Judge3;
    public GameObject Judge4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SwitchDoorScript.isOpen = true;
        if (Judge1.CompareTag("red"))
        {
            if (Judge2.CompareTag("blue"))
            {
                if (Judge3.CompareTag("yellow"))
                {
                    if (Judge4.CompareTag("green"))
                    {
                        SwitchDoorScript.isOpen = true;
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {

    }

}
