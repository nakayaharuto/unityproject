using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image = default;
    Item item = null;
    
    public void Set(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    //ƒXƒƒbƒg‚©‚Ç‚¤‚©‚ğ”»’è‚·‚é
    public bool IsEmpty()
    {
        return item == null;
    }
}
