using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;

public class OptController : MonoBehaviour
{
    [SerializeField] Canvas ItemuCanvas;
    [SerializeField] Canvas MainCanvas;
    [SerializeField] GameObject volumepanel;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject Backpanel;

    [SerializeField] private Slider slider;
    public string Scene; //ワールド移動
    private SoundManager soundManager;
    public Animator animator;

    void Start()
    {

        MainCanvas.gameObject.SetActive(false);
        volumepanel.SetActive(true);
        panel.SetActive(false);
        Backpanel.SetActive(false);

        slider.value = SoundManager.Instance.GetMasterVolume() * 100f;
       
    }

    private void Update()
    {
        //Escキー入力でオプションへ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            option();
        }
    }

    public void option()
    {
        //マウスポインタを表示
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ItemuCanvas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(true);
        Backpanel.SetActive(true);
        //ゲーム停止
        Time.timeScale = 0f;
    }

    public void volume()
    {
        animator.SetTrigger("Down");
        panel.SetActive(true);
    }

    public void OnVolumeChanged(float volume)
    {
        SoundManager.Instance.SetMasterVolume(volume / 100f);
    }

    public void BackScene()
    {
        SceneManager.LoadScene(Scene);
    }

    public void ScaleBack()
    {
        //マウスポインタを非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        ItemuCanvas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
        Backpanel.SetActive(false);
        // 時間を戻してゲーム再開
        Time.timeScale = 1f;
    }

}
