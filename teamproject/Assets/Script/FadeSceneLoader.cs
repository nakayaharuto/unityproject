using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;     //フェード用のUIパネル
    public float fadeDuration;  //フェードの完了

    private void Start()
    {
        //最初は透明で非公開
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0f);
        fadePanel.enabled = false;
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        //フェードアウトアニメーション
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                           //経過時間増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);     //進行度
            fadePanel.color = Color.Lerp(startColor, endColor, t);  //パネルの色変更
            yield return null;                                      //1フレーム大気
        }

        fadePanel.color = endColor;     //フェード完了したら設定
        SceneManager.LoadScene("");     //シーンをロードして移行
    }
}
