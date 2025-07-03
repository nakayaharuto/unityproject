using UnityEngine;
using UnityEngine.UI;

public class Cbutton_push : MonoBehaviour
{
    [SerializeField]public int push_num = 0;
    public Text push_text;
    [SerializeField] private int button_color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        push_text.text = "" + 0;

        switch(button_color)
        {
            case 0:
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                this.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                this.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        push_num++;
        push_text.text = "" + push_num;
    }
}
