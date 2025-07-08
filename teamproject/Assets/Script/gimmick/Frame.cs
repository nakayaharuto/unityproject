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
        if (isFilled) return;
        Item currentitem = itemBox.GetSelectedItem();
        if (currentitem != null && currentitem.type == Itemtype)
        {
            isFilled = true;
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
    public bool IsFilled()
    {
        return isFilled;
    }

}
