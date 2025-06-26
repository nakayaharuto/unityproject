using UnityEngine;

public class greenflaskScprit : MonoBehaviour
{
    private bool isGreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("green"))
        {
            isGreen = true;
        }
    }
}
