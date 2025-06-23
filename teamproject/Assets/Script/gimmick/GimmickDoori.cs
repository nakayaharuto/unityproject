using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GimmickDoori : MonoBehaviour
{
    public numbergimmick[] buttons; //ナンバーギミックのボタンを設定
    public GameObject door;         //ドア

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private　void Start()
    {
        ChackButton();
    }

    private void ChackButton()
    {
        foreach (var button in buttons)
        {
            if (button.CurrentNumber != button.CorrectNumber)
            {
                return;
            }
        }

        //全部正解
        OpenDoor();
    }

    private void OpenDoor()
    {
        //Debug.Log("空きました。");
    }
    
}
