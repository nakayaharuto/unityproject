using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;

    //アクセスし放題
    public static ItemBox instance;

    private void Awake()
    {
        instance = this;
    }

    //アイテムを受け取る処理
    public void SetItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.IsEmpty())//空スロットがあるか
            {
                slot.Set(item);
                break;
            }
        }
    }
}
