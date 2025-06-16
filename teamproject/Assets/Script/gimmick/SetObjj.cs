using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetObjj : MonoBehaviour
{
    [SerializeField] GameObject setobj = default;
    [SerializeField] Item.Type useItem = default;

    public static SetObjj instace;
    public void OnClickThis()
    {
        Debug.Log("ああああああ");
        //適切なアイテムを選択した状態で
        bool hasItem = ItemBox.instance.TryuseItem(useItem);
        if (hasItem)
        {
            //アイテム表示
            setobj.SetActive(true);
        }
    }
}
