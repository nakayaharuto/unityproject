using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;
public class HintMonitor : MonoBehaviour
{
    [SerializeField] public int hint_text_num=0;
    public Text Htext;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hint_text_num = Random.Range(1, 6);

        Htext.color = Color.white;
        

        switch(hint_text_num)
        {
            case 1:
                
                Htext.text = "我が大陸は<color=#EA3520>8</color>地域に分かれている。\n殆どの地域は壊滅している。";
                break;
            case 2:
                
                Htext.text = "New<color=#EA3520>己</color>が信ずる道を進み続けよ。";
                break;
            case 3:
                
                Htext.text = "大陸は暗黒の時代を迎えている。\nだが、必ず<color=#EA3520>日</color>は昇り、新たな時代が\n始まるはずだ。";
                break;
            case 4:
                
                Htext.text = "セクター<color=#EA3520>E</color>の調子が悪い。\nこのままではクローンの製造すら、\n不可能になってしまう。";
                break;
            case 5:
               
                Htext.text = "第<color=#EA3520>3</color>の帝国が崩壊して早数百年、\n人類はどのように歩んでいくのか。";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
