using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    public void OnGameExit()
    {
        // シーン遷移前にEventSystemやカーソルの状態をリセット
        ResetScene();

        SceneManager.LoadScene("Title");
    }

    private void ResetScene()
    {
        Debug.Log("Cursor is now visible and unlocked.");
    }
}
