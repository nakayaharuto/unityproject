using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            DontDestroyOnLoad(gameObject);//シーンまたいでも消さない
            
        }
        else
        {
            Destroy(gameObject); // 重複防止
        }
        InitializeFadeImage();

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeFadeImage(); // シーンが変わるたびに再設定
    }
    private void InitializeFadeImage()
    {
            // "FadeImage"タグを使って再検索する
            GameObject found = GameObject.FindWithTag("FadeImage");
        if (found != null)
        {
            // フェードImageが失われていたら再検索
            FadeImage = found.GetComponentInChildren<Image>(); // 非アクティブでも探す
            if (FadeImage != null)
            {
                // 最初に透明にする
                Color c = FadeImage.color;
                c.a = 0;
                FadeImage.color = c;
            }
            else
            {
                FadeImage.transform.SetParent(this.transform, false); // 念のため親に再設定
            }
        }
        else
        {
            Debug.LogWarning("FadeImage が見つかりません");
        }
    }

    public IEnumerator FadeOut()
    {
        if (FadeImage == null)
        {
            Debug.LogWarning("FadeImage が設定されていません");
            yield break;
        }

        float timer = 0f;
        Color color = FadeImage.color;
        while (timer < FadeDuration)
        {
            float delta = Time.deltaTime;
            timer += delta;
            color.a = Mathf.Lerp(0f,1f, timer / FadeDuration);
            FadeImage.color = color;
            yield return null;
        }
        color.a = 1f;
        FadeImage.color = color;
    }

    public IEnumerator FadeIn()
    {
        if (FadeImage == null)
        {
            Debug.LogWarning("FadeImage が設定されていません");
            yield break;
        }

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
