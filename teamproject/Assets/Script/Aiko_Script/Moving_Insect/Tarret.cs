using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tarret : MonoBehaviour
{


    public GameObject BulletPrefab;
    public float bulletSpeed=500f;
    public int span = 1;
    private int timeCount = 0;

    public GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    private float rot;
    private bool tarret_switch_on = false;
    [SerializeField] private GameObject killzone;

    // Use this for initialization
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "EscortTarget");
    }

    // Update is called once per frame
    void Update()
    {
        if (tarret_switch_on)
        {
            TarretLockOn();
        }

    }

    //指定されたタグの中で最も近いものを取得
   public GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            nearObj = serchTag(other.gameObject, "EscortTarget");
            tarret_switch_on = true;
        }
        


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            tarret_switch_on = false;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, Quaternion.identity.y, 0f));   //敵がいない場合は回転をリセット
        }
    }

    public void TarretLockOn()
    {
        //経過時間を取得
        searchTime += Time.deltaTime;

        if (searchTime >= 0.1f)
        {
            //最も近かったオブジェクトを取得
           

            //経過時間を初期化
            searchTime = 0;
        }

        if (nearObj == null)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, Quaternion.identity.y, 0f));   //敵がいない場合は回転をリセット
        }
        else
        {

            //対象の位置の方向を向く
            transform.LookAt(nearObj.transform);

           transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));

            // transform.rotation = Quaternion.FromToRotation(transform.rotation, Quaternion.LookRotation(nearObj.transform.position - transform.position),120.0f * Time.deltaTime);

            timeCount--;

            if (timeCount < 0)
            {
                timeCount = span;
                // 敵の弾を生成する
                GameObject Bullet = Instantiate(BulletPrefab, new Vector3(this.transform.position.x, nearObj.transform.position.y+0.1f, this.transform.position.z), Quaternion.identity);

                Rigidbody BulletRb = Bullet.GetComponent<Rigidbody>();

                // 弾をforwardに飛ばす
                BulletRb.AddForce(transform.forward * bulletSpeed);

                // ３秒後に弾を削除する。
                Destroy(Bullet, 3.0f);
            }
        }
    }

}
