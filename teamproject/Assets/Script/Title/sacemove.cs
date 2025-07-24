using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.XR;

public class sacemove : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // 移動先のシーン名
    public FadeController FadeImage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportWithFade(other));

        }
        else
        {
            Debug.Log("シーン移動場所が消えている");
        }
    }

    private IEnumerator TeleportWithFade(Collider player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller == null || FadeImage == null)
            yield break;

        //ワープの瞬間コントローラー無効化
        controller.enabled = false;
        //フェードアウト
        yield return StartCoroutine(FadeImage.FadeOut());

        //シーン移動
        SceneManager.LoadScene(nextSceneName);

        controller.enabled = true;
        //フェードイン
        yield return StartCoroutine(FadeImage.FadeIn());

    }

}
