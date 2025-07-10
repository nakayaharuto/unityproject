using UnityEngine;

public class Frame : MonoBehaviour
{
    public Item.Type Itemtype;    //フレームにあうItemのtype
    private bool isFilled = false;
    [SerializeField] private Transform displaypoint;
    private GameObject displayobject = null;

    //サウンドマネージャー
    [SerializeField] private SoundManager soundManager;

    public void TryInsertItem(Item.Type itemtype,ItemBox itemBox)
    {
        if (isFilled)
        {
            RemoveItem(itemBox);
        }
        isFilled = true;
        Item currentitem = itemBox.GetSelectedItem();
        if (currentitem != null && currentitem.type == Itemtype)
        {
            itemBox.UseSelectItem();
            if(currentitem.throwprefab != null)
            {
                displayobject = Instantiate(currentitem.throwprefab, displaypoint.position, displaypoint.rotation);
                displayobject.transform.SetParent(displaypoint); // 枠に追従させる（任意）
            }
            soundManager.Play(SoundManager.SoundType.correctans); //サウンドマネージャーを使用して効果音再生
        }
        else
        {
            soundManager.Play(SoundManager.SoundType.Incorrectans);
        }
    }

    public void RemoveItem(ItemBox itembox)
    {
        if (!isFilled || displayobject == null) return;

        //プレイヤーのインベントリに戻す
        Item item = displayobject.GetComponent<Item>();
        if (item != null)
        {
            // ItemBox に空きがあれば戻す
            bool added = itembox.SetItem(item);
            if (!added)
            {
                Debug.LogWarning("ItemBox is full! 取り外せません");
                return;
            }
        }

        Destroy(displayobject);
        displayobject = null;
        isFilled = false;
    }

    public bool IsFilled()
    {
        return isFilled;
    }

    // 例：クリックで取り外せるようにする
    private void OnMouseDown()
    {
        // 取り外し
        if (Input.GetMouseButtonDown(0))
        {
            if(isFilled)
            {
                RemoveItem(ItemBox.instance); // static インスタンスから参照
            }
            else
            {
                TryInsertItem(ItemBox.instance.GetSelectedItem().type, ItemBox.instance);
            }
        }
    }

}
