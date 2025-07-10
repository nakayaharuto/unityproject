using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Rendering;
using UnityEngine.Analytics;

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
        
        PlayerPrefs.DeleteKey("playerPosX");
        PlayerPrefs.DeleteKey("playerPosY");
        PlayerPrefs.DeleteKey("playerPosZ");

        StartCoroutine(LoadSceneWithFade());
 
    }

    public void OnContine()
    {
        string savescene = PlayerPrefs.GetString("SaveScene", "level1");// デフォルトは最初のシーン
        //続きから
        StartCoroutine(SaveSceneWithFade(savescene));

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
        if (SaveSystem.HasSaveData())
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
        Debug.Log("コルーチン開始");
        soundManager.Play(SoundManager.SoundType.choice);
        if (FadeController.Instance != null)
        {
            // フェードアウト（画面を暗く）
            Debug.Log("フェードアウト開始");
            yield return FadeController.Instance.FadeOut();
            Debug.Log("フェードアウト完了");
        }
        else
        {
            Debug.LogWarning("FadeController.Instance が null！");
        }
        // シーンを非同期ロード
        Debug.Log("シーン遷移開始");
        SceneManager.LoadScene(Scene);
    }

    private IEnumerator SaveSceneWithFade(string SceneName)
    {
        soundManager.Play(SoundManager.SoundType.choice);
        if (FadeController.Instance != null)
        {
            // フェードアウト（画面を暗く）
            Debug.Log("フェードアウト開始");
            yield return FadeController.Instance.FadeOut();
            Debug.Log("フェードアウト完了");
        }
        // セーブしたシーンをロード
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // プレイヤー位置を復元する処理
        RestorePlayerPosition();
    }
    void RestorePlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("playerPosX", 0);
        float y = PlayerPrefs.GetFloat("playerPosY", 0);
        float z = PlayerPrefs.GetFloat("playerPosZ", 0);

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = SaveSystem.LoadPlayerPosition();
        }
    }
}
