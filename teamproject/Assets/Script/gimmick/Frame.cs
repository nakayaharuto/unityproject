using UnityEngine;

public class Frame : MonoBehaviour
{
    public Item.Type Itemtype;    //フレームにあうItemのtype
    private bool isFilled = false;

    //サウンドマネージャー
    [SerializeField] private SoundManager soundManager;

    public void TryInsertItem(Item.Type itemtype,ItemBox itemBox)
    {
        if (isFilled) return;
        Item currentitem = itemBox.GetSelectedItem();
        if (currentitem != null && currentitem.type == Itemtype)
        {
            isFilled = true;
            ItemBox.instance.UseSelectItem();
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
