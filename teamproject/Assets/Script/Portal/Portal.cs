using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform LevelPotal;//相手側のポータルの位置
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                
                //ワープの瞬間コントローラー無効化
                controller.enabled = false;
                Debug.Log("...");
                other.transform.position = LevelPotal.position + LevelPotal.forward * 2.0f;
                controller.enabled = true;
            }
        }
    }
}
