using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class numbergimmick : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI VerText;
    private int NowNumber = 0;
    

    public void OnPressed()
    {
        Debug.Log("osaremasita ");
    }

    private void OnMouseDown()
    {
        NowNumber++;//âüÇ≥ÇÍÇΩÇÁêîílëùÇ‚Ç∑
        if (NowNumber > 9)//9à»è„Ç…Ç»Ç¡ÇΩÇÁ0Ç…ñﬂÇ∑
        {
            NowNumber = 0;
        }
        string Number = NowNumber.ToString();
        if (VerText != null)
        {
            VerText.text = Number;
        }
        OnPressed();
    }
}
