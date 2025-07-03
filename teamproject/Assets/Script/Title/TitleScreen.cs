using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class TitleScreen : MonoBehaviour
{
    public string Scene; //ƒ[ƒ‹ƒhˆÚ“®
    public Canvas OptionCanvas;

    public void OnNewGame()
    {
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        PlayerPrefs.DeleteKey("PositionZ");

        SceneManager.LoadScene(Scene);
    }

    public void OnContine()
    {
        //‘±‚«‚©‚ç
        SceneManager.LoadScene(Scene);
    }

    public void OnOption()
    {
        OptionCanvas.gameObject.SetActive(true);
    }

}
