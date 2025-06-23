using UnityEngine;

/// <summary>
/// <see cref="Slot">Slotリンク</see>
/// </summary>


public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots = default;

    int SelectIndex = -1;

    //アクセスし放題
    public static ItemBox instance;
    Slot selectSlot;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll > 0f)
        {
            SelectPreviousSlot();
        }
        else if(scroll < 0f)
        {
            SelectNextSlot();
        }
    }

    public void OnSlotClick(int position)
    {
        if (slots[position].IsEmpty()) return;//空スロットなら何もしない

        // すべてのスロットの選択枠を非表示にする
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].HideBackPanel();
        }

        // クリックしたスロットの枠を表示
        slots[position].OnSelect();
        selectSlot = slots[position]; // 選択状態として保存
    }

    public bool TryuseItem(Item.Type useItem)
    {
        Item selecteditem = GetSelectedItem();

        if(selecteditem != null && selecteditem.type == useItem)
        {
            UseSelectItem();
            return true;
        }
        return false;
    }
    //スロットの枠をスクロールで選択する
    void SelectPreviousSlot()
    {
        if (slots.Length == 0) return;

        int attempts = 0;
        do
        {
            SelectIndex--;
            if (SelectIndex < 0) SelectIndex = slots.Length - 1;
            if (!slots[SelectIndex].IsEmpty())
            {
                Debug.Log("前");
                OnSlotClick(SelectIndex);
                return;
            }
            attempts++;
        } while (attempts < slots.Length);
    }

    //スロットの枠をスクロールで選択する
    void SelectNextSlot()
    {
        if (slots.Length == 0) return;
        
        int attempts = 0;
        do
        {
           
            SelectIndex++;
            if (SelectIndex >= slots.Length) SelectIndex = 0;
            if (!slots[SelectIndex].IsEmpty())
            {
                Debug.Log("次");
                OnSlotClick(SelectIndex);
                return;
            }
            attempts++;
        }while (attempts < slots.Length);
    }
    //アイテムを受け取る処理
    public bool SetItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.IsEmpty())//空スロットがあるか
            {
                slot.Set(item);

                if (SelectIndex == -1) SelectIndex = i;//初回に選択インデックスを決める
                return true;
            }
        }
        return false;
    }

    public Item GetSelectedItem()
    {
        return selectSlot?.GetItem();
    }

    public void UseSelectItem()
    {
        if (selectSlot != null)
        {
            selectSlot.RemoveItem();//スロットから削除
            selectSlot = null;//選択状態も解除

        }
    }
}
