using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class numbergimmick : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI VerText;
    int NowNumber = 0;

    public void OnPressed()
    {
        Debug.Log("osaremasita ");
    }

    private void OnMouseDown()
    {
        NowNumber++;
        string Number = NowNumber.ToString();
        if (VerText != null)
        {
            VerText.text = Number;
        }
        OnPressed();
    }









    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("button"))
    //    {
    //        NowNumber++;

    //        string Number = NowNumber.ToString();

    //        VerText.text = Number;
    //    }
    //}
}
