using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    public Image FadeImage;
    public float FadeDuration = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(FadeImage == null)
        {
            Debug.Log("ê›íËÇ≥ÇÍÇƒÇ‹ÇπÇÒ");
            this.enabled = false;
        }
    }

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = FadeImage.color;
        while(timer < FadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f,1f, timer / FadeDuration);
            FadeImage.color = color;
            yield return null;
        }
        color.a = 1f;
        FadeImage.color = color;
    }

    public IEnumerator FadeIn()
    {
        float timer = 0f;
        Color color = FadeImage.color;
        while (timer < FadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / FadeDuration);
            FadeImage.color = color;
            yield return null;
        }
        color.a = 0f;
        FadeImage.color = color;
    }
}
