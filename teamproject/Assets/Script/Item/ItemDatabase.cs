using UnityEngine;

/// <summary>
/// <see cref="ItemBox">ItemBoxリンク</see>
/// </summary>

public class ItemDatabase : MonoBehaviour
{
    //アクセスし放題
    public static ItemDatabase Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] ItemDatabaseEntity itemDatabaseEntity = default;
    
    public Item Spawn(Item.Type type)
    {
        foreach(Item itemData in itemDatabaseEntity.items)
        {
            //データベースから一致するアイテムを探す
            if(itemData.type == type)
            {
                return new Item(itemData);
            }
        }
        return null;
    }
}
