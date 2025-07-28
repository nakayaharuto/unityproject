using UnityEngine;
using UnityEngine.SceneManagement;

public class sacene : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // 移動先のシーン名
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーと衝突したとき
        {
            if (FadeController.Instance != null)
            {
                StartCoroutine(FadeController.Instance.FadeOut());
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
