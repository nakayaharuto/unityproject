using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(2)]
public class Stone_Monitor : MonoBehaviour
{
    public Text moni_text;
    [SerializeField] private Text stone_text;
    [SerializeField] private Stone_Rotatiton SR;
    [SerializeField] private GameObject stone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SR=stone.GetComponent<Stone_Rotatiton>();
        stone_text=stone.GetComponentInChildren<Text>();

        switch(SR.rannum_true_stone)
        {
            case 0:
                moni_text.text = stone_text.text + "は決して振り返らない。";
                break;
            case 1:
                moni_text.text = stone_text.text + "は夜明けが好き。";
                break;
            case 2:
                moni_text.text = stone_text.text + "は夕焼けをよく見ている。";
                break;
            case 3:
                moni_text.text = stone_text.text + "は過去に囚われている。";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
