using UnityEngine;

public class Lesar_Flag_Script : MonoBehaviour
{
    public bool Lesar_Flag = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaa");
        Lesar_Flag = false;
        if (collision.gameObject.CompareTag("Crane"))
        {
            Lesar_Flag = false;
            Debug.Log("bbbb");
        }
    }

}
