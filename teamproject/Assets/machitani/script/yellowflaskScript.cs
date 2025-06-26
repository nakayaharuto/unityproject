using UnityEngine;

public class yellowflaskScript : MonoBehaviour
{
    private bool isYellow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isYellow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("yellow"))
        {
            isYellow = true;  
        }
    }
}
