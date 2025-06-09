using UnityEngine;

/// <summary>
/// <see cref="Slot">Slotリンク</see>
/// </summary>
public class PickupObject : MonoBehaviour
{
    //取得するアイテムの種類を設定
    public Item.Type type = default;

    //アイテムをFキーで入手
    public void OnClickObject()
    {
        //アイテムデータベース空アイテム情報を取得
        Item item = ItemDatabase.Instance.Spawn(type);

        if (item != null)
        {
            ItemBox.instance.SetItem(item);
        }

        gameObject.SetActive(false);
    }
}
