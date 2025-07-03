using UnityEngine;
using UnityEngine.UI;
public class HintMonitor : MonoBehaviour
{
    [SerializeField] public int hint_text_num;
    public Text Htext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hint_text_num = Random.Range(1, 6);

        switch(hint_text_num)
        {
            case 1:
                Htext.text = "8";
                break;
            case 2:
                Htext.text = "ŒÈ";
                break;
            case 3:
                Htext.text = "“ú";
                break;
            case 4:
                Htext.text = "E";
                break;
            case 5:
                Htext.text = "3";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
