using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectOptions : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    [SerializeField] List<bool> keys;

    public int Selected
    {
        get
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i])
                    return i;
            }

            return -1;
        }
    }

    public IEnumerator CorGetInput()
    {
        //keysをすべてfalseにする
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i] = false;
        }

        //ゲームオブジェクトを表示
        gameObject.SetActive(true);

        //いずれかのボタンが押されるまで待機
        yield return new WaitWhile(() => Selected == -1);

        //ゲームオブジェクトを非表示
        gameObject.SetActive(false);
    }

    // 各ボタンに処理を割り当て
    void Start()
    {
        //keysをbuttonsと同じ長さに
        keys = Enumerable.Repeat(false, buttons.Count).ToList();


        //各ボタンに処理を割り当てる
        for (int i = 0; i < buttons.Count; i++)
        {
            //一旦別の変数に格納しないとエラー発生
            int a = i;

            //buttonを押すと該当するkeyをtrueに
            buttons[a].onClick.AddListener(() => keys[a] = true);
        }

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
