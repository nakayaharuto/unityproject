using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.XR;

public class sacemove : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // 移動先のシーン名
    public FadeController fadecontroller;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportWithFade(other));

        }
    }

    private IEnumerator TeleportWithFade(Collider player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller == null || fadecontroller == null)
            yield break;

        //ワープの瞬間コントローラー無効化
        controller.enabled = false;
        //フェードアウト
        yield return StartCoroutine(fadecontroller.FadeOut());

        //シーン移動
        SceneManager.LoadScene(nextSceneName);

        controller.enabled = true;
        //フェードイン
        yield return StartCoroutine(fadecontroller.FadeIn());

    }

}
