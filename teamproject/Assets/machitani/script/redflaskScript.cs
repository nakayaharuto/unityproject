using UnityEngine;

public class redflaskScript : MonoBehaviour
{
    public SwitchDoorScript SwitchDoorScript;
    private bool isRed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Red"))
        {
            SwitchDoorScript.isOpen = true;
        }
    }
}
