using UnityEngine;

public class StartFade : MonoBehaviour
{
    private void Start()
    {
        if(FadeController.Instance != null)
        {
            StartCoroutine(FadeController.Instance.FadeIn());
        }
        
    }
}