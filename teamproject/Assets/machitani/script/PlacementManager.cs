using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public SpotChecker[] spots; // 全てのスポットを登録
    public SwitchDoorScript SwitchDoorScript;

    void Update()
    {
        if (AllItemsCorrectlyPlaced())
        {
            SwitchDoorScript.isOpen = true;
            // 一度だけ実行するなら、フラグで制御
        }
    }

    bool AllItemsCorrectlyPlaced()
    {
        foreach (var spot in spots)
        {
            if (!spot.isCorrect)
                return false;
        }
        return true;
    }
}
