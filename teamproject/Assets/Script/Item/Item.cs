using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
        kyecade_yellow,
        kyecade_bule,
        white_Cube,
        white_Traiangl,
        white_Sphere,
        red_Cube,
        red_Sphere,
        red_Triangle,
        green_Triangle,
        green_Sphere,
        green_Cube,
        blue_Cube,
        blue_Sphere,
        blue_Traiangl,
        yellow_cube,
        yellow_Sphere,
        yellow_Traiangl,
        red_vitro,
        bule_vitro,
        yellow_vitro,
        green_vitro,
        blue,
        red,
        yellow,
        green,
        kyecade_black,
        purple_cube,
    }
    //アイテムのタイプ
    public Type type;

    //画像
    public Sprite sprite;

    //投げるプレハブ
    public GameObject throwprefab;

    //コンストラクタ
    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
        this.throwprefab = item.throwprefab;
    }
}
