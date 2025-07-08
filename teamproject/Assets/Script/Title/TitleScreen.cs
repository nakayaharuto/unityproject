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

    //サウンドマネージャー
    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        OptionCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }


    public void OnNewGame()
    {
        soundManager.Play(SoundManager.SoundType.choice);
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        PlayerPrefs.DeleteKey("PositionZ");

        SceneManager.LoadScene(Scene);
    }

    public void OnContine()
    {
        soundManager.Play(SoundManager.SoundType.choice);
        //続きから
        SceneManager.LoadScene(Scene);
       
    }

    public void OnOption()
    {
        OptionCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);

    }

}
