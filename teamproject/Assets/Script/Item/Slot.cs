using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// <see cref="PickupObject">PickupObjectリンク</see>
/// </summary>

public class Slot : MonoBehaviour
{
    [SerializeField] Image image = default;         //アイテム画像
    [SerializeField] GameObject backPanel = default;//選択枠
    Item item = null;//アイテム情報

    private void Start()
    {
        //初期状態枠非表示
        backPanel.SetActive(false);
    }

    //アイテムスロットにセット
    public void Set(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;//アイテムの画像をセット
    }

    //アイテムをスロットから削除
    public void RemoveItem()
    {
        item = null;
        image.sprite = null;
        image.enabled = false;
        HideBackPanel();//枠非表示
    }
    //アイテム情報を取得
    public Item GetItem()
    {
        return item;
    }
    //スロットが空かどうかを判定する
    public bool IsEmpty()
    {
        return item == null;
    }

    //アイテムを選択したときに枠を表示
    public void OnSelect()
    {
        backPanel.SetActive(true);
    }
    //選択を解除
    public void HideBackPanel()
    {
        backPanel.SetActive(false);
    }

}
