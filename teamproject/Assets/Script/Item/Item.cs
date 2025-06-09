using System;
using UnityEngine;

/// <summary>
/// <see cref="ItemDatabaseEntity">ItemDatabaseEntityリンク</see>
/// </summary>

/// <summary>
/// <see cref="ItemDatabase">ItemDatabaseリンクへ</see>
/// </summary>
[System.Serializable]//Inspector
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

    //投げるようプレハブ
    public GameObject throwprefab;

    //コンストラクタ
    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
    }
}
