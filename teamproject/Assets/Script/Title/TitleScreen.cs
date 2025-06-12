using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void OnNewGame()
    {
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
        PlayerPrefs.DeleteKey("PositionZ");

        SceneManager.LoadScene("level3");
    }

    public void OnContine()
    {
        //‘±‚«‚©‚ç
        SceneManager.LoadScene("level3");
    }

    public void OnOption()
    {
        //ƒIƒvƒVƒ‡ƒ“
        Debug.Log("Option Screen open");
    }

}
