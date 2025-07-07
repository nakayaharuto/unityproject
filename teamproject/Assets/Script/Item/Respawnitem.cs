using UnityEngine;

public class Respawnitem : MonoBehaviour
{
    public GameObject Item;
    public Transform SpawnPoint;
    public float SpawnTime = 2;

    private GameObject CurrentItem;     //原罪のアイテム

    private void Start()
    {
        InvokeRepeating(nameof(CheckAndSpawn), 0f, SpawnTime);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(CurrentItem);
        }
    }

    void CheckAndSpawn()
    {
        if (CurrentItem == null || CurrentItem.Equals(null))
        {
            //itemなければ再度生成
            CurrentItem = Instantiate(Item, SpawnPoint.position,SpawnPoint.rotation);
        }
    }

}
