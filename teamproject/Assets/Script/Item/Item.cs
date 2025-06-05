using System;
using UnityEngine;

[Serializable]//Inspector
public class Item
{
    public enum Type
    {
        //アイテムを追加していく場合はここ
        kyecade_red,
        Cube,
        Sphere,
        Triangle,

    }

    //アイテムのタイプ
    public Type type;

    //画像
    public Sprite sprite;

    //コンストラクタ
    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
    }
}
