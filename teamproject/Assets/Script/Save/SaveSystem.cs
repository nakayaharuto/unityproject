using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    //セーブ用のキー
    private const string PositionXKey = "playerPosX";
    private const string PositionYKey = "playerPosY";
    private const string PositionZKey = "playerPosZ";
    private const string SceneKey = "SaveScene";

    public static void SavePlayerPosition(Transform playerTransform)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(SceneKey, currentScene);
        //プレイヤーの位置保存
        PlayerPrefs.SetFloat(PositionXKey,playerTransform.position.x);
        PlayerPrefs.SetFloat(PositionYKey,playerTransform.position.y);
        PlayerPrefs.SetFloat(PositionZKey,playerTransform.position.z);
        PlayerPrefs.Save();
    }

    public static Vector3 LoadPlayerPosition()
    {
        //保存された位置を読み込む
        float x = PlayerPrefs.GetFloat(PositionXKey, 0f);
        float y = PlayerPrefs.GetFloat(PositionYKey, 0f);
        float z = PlayerPrefs.GetFloat(PositionZKey, 0f);

        return new Vector3(x,y,z);
    }

    public static bool HasSaveData()
    {
        //保存されてるかの確認
        return PlayerPrefs.HasKey(PositionXKey);
    }

    
}
