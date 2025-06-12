using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform LevelPortal;//相手側のポータルの位置
    public FadeController fadecontroller;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(TeleportWithFade(other));
        }
    }

    private IEnumerator TeleportWithFade(Collider player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller == null || fadecontroller == null)
            yield break;

        //フェードアウト
        yield return StartCoroutine(fadecontroller.FadeOut());

        //ワープ処理
        //ワープの瞬間コントローラー無効化
        controller.enabled = false;
        player.transform.position = LevelPortal.position + LevelPortal.forward * 2.0f;
        player.transform.rotation = LevelPortal.rotation;
        controller.enabled = true;

        //フェードイン
        yield return StartCoroutine(fadecontroller.FadeIn());
    }

}
