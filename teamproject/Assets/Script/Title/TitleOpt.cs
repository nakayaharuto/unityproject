using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleOpt : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SoundManager soundManager;

    public Canvas optcanvas;    //オプションキャンバス
    public Canvas maincanvas;   //メインキャンヴァス


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 100f);
        slider.value = savedVolume;
        SoundManager.Instance.SetMasterVolume(savedVolume / 100f);
        maincanvas.gameObject.SetActive(false);
        slider.value = SoundManager.Instance.GetMasterVolume() * 100f;
    }
    public void OnVolumeChanged(float volume)
    {
        SoundManager.Instance.SetMasterVolume(volume / 100f);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void BackScene()
    {
        optcanvas.gameObject.SetActive(false);
        maincanvas.gameObject.SetActive(true);
        soundManager.Play(SoundManager.SoundType.choice);
    }
}
