using UnityEngine;
using UnityEngine.UI;

public class OptController : MonoBehaviour
{
    public static OptController instance;
    public GameObject MainCanvas;
    public GameObject SubCanvas;

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume; //‰Šú‰¹—Ê‚ðÝ’è
    }

    public void OptEnble()
    {
        MainCanvas.SetActive(false);
        SubCanvas.SetActive(true);
        slider.value = AudioListener.volume;

        slider.onValueChanged.AddListener((SetVolume) => AudioListener.volume = SetVolume);
    }

    public void GameOption()
    {
        MainCanvas.SetActive(false);
        SubCanvas.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainCanvas.SetActive(true);
            SubCanvas.SetActive(false);
        }
    }

}
