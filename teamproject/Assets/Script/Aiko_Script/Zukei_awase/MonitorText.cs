using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(5)]
public class MonitorText : MonoBehaviour
{
    //public GameObject Monitor;
    public Text moni_text;
    [SerializeField]private int[] appear_num;
    ShapeRotate SR;
    NumCheckiAnswer NCA;
    public GameObject[] rl_buttons;
    [SerializeField]private int button_num=0;
    [SerializeField] private SoundManager SM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       appear_num = new int[4];

        NCA=GameObject.Find("Num_Check_Answer").GetComponent<NumCheckiAnswer>();

        for (int i = 0; i < 4; i++)
        {
            SR = NCA.rotate_objects[i].GetComponent<ShapeRotate>();



            Debug.Log("bbbb" + SR.name);
            Debug.Log(SR.random_num);
            appear_num[i] = SR.random_num;
            Debug.Log("aaaaaa" + appear_num[i]);


        }

        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnMouseDown()
    {
       

        }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == rl_buttons[0])
                {
                    if (button_num>0)
                    {
                        button_num--;
                    }

                    SM.Play(SoundManager.SoundType.choice); //サウンドマネージャーを使用して効果音再生
                    Debug.Log("left");
                }
                else if (hit.collider.gameObject == rl_buttons[1])
                {

                    if (button_num < 3)
                    {
                        button_num++;
                    }
                    SM.Play(SoundManager.SoundType.choice); //サウンドマネージャーを使用して効果音再生
                    Debug.Log("right");
                }
                TextAppear();
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        
    }

    public void TextAppear()
    {
        
        switch(button_num)
        {
            case 0:
                moni_text.text = "太陽から見て" + appear_num[0]+"個目の惑星が\n我々の惑星だ。";
                break;
            case 1:
                moni_text.text = "月の満ち欠けはおおよそ" + appear_num[1]+"日周期だ。";
                break;
            case 2:
                moni_text.text = "ミサイルが" + appear_num[2]+"日の間、降り注いだ。";
                break;
            case 3:
                moni_text.text = "最後に雨が降ったのはいつだったか。\n" +"おおよそ"+ appear_num[3]+"年前だったか。";
                break;
        }

    }


}
