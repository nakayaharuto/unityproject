using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeSceneLoader : MonoBehaviour
{
    public float fadeDuration;  //フェードの完了
    public FadeController fadecontroller;
    public string Scene;        //ワールド移動

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

        SceneManager.LoadScene(Scene);

        controller.enabled = true;
        //フェードイン
        yield return StartCoroutine(fadecontroller.FadeIn());

    }
}
