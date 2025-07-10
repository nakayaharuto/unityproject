using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleOpt : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SoundManager soundManager;

    public Canvas optcanvas;    //オプションキャンバス
    public Canvas maincanvas;   //メインキャンヴァス

    [SerializeField] GameObject CRpanel;//クレジットパネル
    [SerializeField] GameObject operationpanel;
    [SerializeField] Button button;
    [SerializeField] Button Backbutton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 100f);
        slider.value = savedVolume;
        SoundManager.Instance.SetMasterVolume(savedVolume / 100f);
        maincanvas.gameObject.SetActive(false);
        operationpanel.SetActive(false);
        Backbutton.gameObject.SetActive(false);
        slider.value = SoundManager.Instance.GetMasterVolume() * 100f;
    }
    public void OnVolumeChanged(float volume)
    {
        SoundManager.Instance.SetMasterVolume(volume / 100f);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void operation()
    {
        CRpanel.SetActive(false);
        operationpanel.SetActive(true);
        button.gameObject.SetActive(false);
        Backbutton.gameObject.SetActive(true);
    }
    public void CRzipanel()
    {
        CRpanel.SetActive(true);
        operationpanel.SetActive(false);
        button.gameObject.SetActive(true);
        Backbutton.gameObject.SetActive(false);
    }

    public void BackScene()
    {
        optcanvas.gameObject.SetActive(false);
        maincanvas.gameObject.SetActive(true);
        soundManager.Play(SoundManager.SoundType.choice);
    }
}
