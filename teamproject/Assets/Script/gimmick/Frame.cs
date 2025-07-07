using UnityEngine;

public class Frame : MonoBehaviour
{
    public Item.Type Itemtype;    //フレームにあうItemのtype
    private bool isFilled = false;

    public void TryInsertItem(Item.Type itemtype,ItemBox itemBox)
    {
        if (isFilled) return;
        Item currentitem = itemBox.GetSelectedItem();
        if (currentitem != null && currentitem.type == Itemtype)
        {
            isFilled = true;
            ItemBox.instance.UseSelectItem();

            Debug.Log($"フレームにアイテム {Itemtype} をはめ込みました！");
        }
        else
        {
            Debug.Log("違うアイテムか選択されていません。");
        }
    }
    public bool IsFilled()
    {
        return isFilled;
    }

}
