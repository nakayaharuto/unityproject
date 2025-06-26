using UnityEngine;

public class SpotChecker : MonoBehaviour
{
    public string correctItemTag; // このスポットに置くべきアイテムのTag
    public bool isCorrect = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctItemTag))
        {
            isCorrect = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(correctItemTag))
        {
            isCorrect = false;
            
        }
    }
}
