using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public static key instance;
    public GameObject KeyCard;  //指定のキーカード
    private GameObject heldItem;
    private Item currentDisplayedItem = null;
    private Animator animator;//ドアのアニメーター

    private void Awake()
    {
        instance = this;
    }
    public void KeyDoor()
    {
        Item currentitem = ItemBox.instance.GetSelectedItem();
        Debug.Log("KeyDoor 呼び出されたよ！");

        if (currentitem != null && currentitem.type == Item.Type.kyecade_red)
        {
            OpenDoor();
            ItemBox.instance.UseSelectItem();
        }
        else
        {
            return;
        }
    }

    public void SetheldItem(GameObject item)
    {
        heldItem = item;
        // スロットから削除＆表示更新
        ItemBox.instance.UseSelectItem();
        currentDisplayedItem = null;
        Destroy(heldItem);
        heldItem = null;
    }

    void OpenDoor()
    {
        Debug.Log("空きました");
    }

}
