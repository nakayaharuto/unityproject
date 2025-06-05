using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDatabase/ItemData")]
public class ItemDatabaseEntity : ScriptableObject
{
    public List<Item> items = new List<Item>();
}
