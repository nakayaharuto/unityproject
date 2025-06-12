using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //トリガーに触れたらセーブ
            SaveSystem.SavePlayerPosition(other.transform);
            Debug.Log("Game Saved!");
        }
    }
}
