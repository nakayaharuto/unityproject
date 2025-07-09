using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    public static FadeController Instance { get; private set; }
    public Image FadeImage;
    public float FadeDuration = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // シングルトン＆永続化
        if (Instance == null)
        {
            Instance = this;

            transform.SetParent(null);//ルート外に一時的に除外
            DontDestroyOnLoad(gameObject);//シーンまたいでも消さないようするらしい
            
        }

        if (FadeImage != null)
        {
            // 最初に透明にする
            Color c = FadeImage.color;
            c.a = 0;
            FadeImage.color = c;
        }
    }
    private void OnEnable()
    {
        if (FadeImage == null)
        {
            // フェードImageが失われていたら再検索
            FadeImage = GetComponentInChildren<Image>(true); // 非アクティブでも探す
            if (FadeImage == null)
            {
                Debug.LogError("FadeImage が再取得できません！");
            }
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
