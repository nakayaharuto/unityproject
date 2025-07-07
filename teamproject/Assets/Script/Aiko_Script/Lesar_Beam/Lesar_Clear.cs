using UnityEngine;

public class Lesar_Clear : MonoBehaviour
{
    public bool lesar_clear=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {
        this.GetComponent<Renderer>().material.color = Color.green;


    }

}
