using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Rendering;

public class TitleScreen : MonoBehaviour
{
    public string Scene; //ワールド移動
    public Canvas OptionCanvas;
    public Canvas mainCanvas;

    //フェードコントローラー
    [SerializeField] private FadeController fadeController;
    //サウンドマネージャー
    [SerializeField] private SoundManager soundManager;

    [SerializeField] private Button continebutton;//参照を追加

    public void OnNewGame()
    {
        soundManager.Play(SoundManager.SoundType.choice);
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        PlayerPrefs.DeleteKey("PositionZ");

        StartCoroutine(LoadSceneWithFade());
    }

    public void OnContine()
    {
        soundManager.Play(SoundManager.SoundType.choice);
        //続きから
        StartCoroutine(LoadSceneWithFade());

    }

    public void OnOption()
    {
        OptionCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        OptionCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);

        //セーブデータがあるかtyっく
        if (PlayerPrefs.HasKey("PositionX") &&
            PlayerPrefs.HasKey("PositionY") &&
            PlayerPrefs.HasKey("PositionZ"))
        {
            continebutton.interactable = true;//有効
        }
        else
        {
            continebutton.interactable = false;//無効
        }

    }
    private IEnumerator LoadSceneWithFade()
    {
        if (FadeController.Instance != null)
        {
            // フェードアウト（画面を暗く）
            yield return FadeController.Instance.FadeOut();
        }
        else
        {
            Debug.Log("nullになってるよ");
        }

       // シーンを非同期ロード
        SceneManager.LoadScene(Scene);
    }

}
