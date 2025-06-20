using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class numbergimmick : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI VerText;
    private int NowNumber = 0;
    public int CurrentNumber => NowNumber;//外から取得
    public int CorrectNumber;

    //範囲内にランダムでcubeを出現させる
    public GameObject spawn;
    public Vector3 SpawnAreaMin;    //範囲の最小値
    public Vector3 SpawnAreaMax;    //範囲の最大値
    private int SpawnCount = 9;

    private void Start()
    {
        SpawnCount = Random.Range(1, SpawnCount);   //出現される最小と最大
        CorrectNumber = SpawnCount;
        for (int i = 0; i < SpawnCount; i++)
        {
            SpawnObjects();
        }
        GameObject[] redspawn = GameObject.FindGameObjectsWithTag("red");
        GameObject[] greenspawn = GameObject.FindGameObjectsWithTag("green");
        GameObject[] bluespawn = GameObject.FindGameObjectsWithTag("blue");
    }

    private void SpawnObjects()
    {
        //位置を計算
        float x = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
        float y = Random.Range(SpawnAreaMin.y, SpawnAreaMax.y);
        float z = Random.Range(SpawnAreaMin.z, SpawnAreaMax.z);

        Vector3 randomPosition = new Vector3(x, y, z);

        //オブジェクト生成
        Debug.Log("生成されとります！");
        Instantiate(spawn, randomPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        // ワイヤーフレームボックスの色
        Gizmos.color = Color.cyan;

        // ボックスの中心とサイズを計算
        Vector3 center = (SpawnAreaMin + SpawnAreaMax) * 0.5f;
        Vector3 size = SpawnAreaMax - SpawnAreaMin;

        // ワイヤーフレームボックスを描画
        Gizmos.DrawWireCube(center, size);
    }
    private void OnMouseDown()
    {
        NowNumber++;//押されたら数値増やす
        if (NowNumber > 9)//9以上になったら0に戻す
        {
            NowNumber = 0;
        }
        if (VerText != null)
        {
            VerText.text = NowNumber.ToString();
        }

    }
}
