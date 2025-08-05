using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class Tarret : MonoBehaviour
{


    public GameObject BulletPrefab;
    public float bulletSpeed=500f;
    public int span = 1;
    public int timeCount = 0;

    public GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    private float rot;
   [SerializeField] public bool tarret_switch_on = false;
    [SerializeField] private GameObject killzone;
    [SerializeField] private GameObject tarret_muzzle;
    public Vector3 hit_pos;
    [SerializeField] public LesarSight LS;
    //[SerializeField] private GameObject bullet;
    [SerializeField] public GameObject kill_target;
    [SerializeField] private float start_rot_y;
    [SerializeField] private SoundManager SM;
    //[SerializeField] private int in_collider_num=0;
    // Use this for initialization
    void Start()
    {
        // bullet = transform.GetChild(1).gameObject;
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "EscortTarget");
        tarret_muzzle=transform.GetChild(0).gameObject;
        LS=this.gameObject.GetComponentInChildren<LesarSight>();
        //tarret_muzzle.GetComponent<ParticleSystem>().Stop();
        start_rot_y=this.transform.eulerAngles.y;
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tarret_switch_on)
        {
            serchTag(gameObject, "EscortTarget");
            TarretLockOn();
            timeCount--;
           // tarret_muzzle.GetComponent<ParticleSystem>().Play();
        }

        if (nearObj == null)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, start_rot_y, 0f));   //敵がいない場合は回転をリセット
           LS.lesar_fire_flag = false;
            tarret_switch_on=false;
            //tarret_muzzle.GetComponent<ParticleSystem>().Stop();
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
           
            //Debug.Log("obj+"+obs.name);

            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                //nearDis = tmpDis;
                //targetObj = obs;

                if (nowObj.GetComponent<Move_Insect>())
                {
                    nowObj.GetComponent<Move_Insect>();

                    if ( nowObj.GetComponent<Move_Insect>().invation_flag == true)
                    {
                        nearDis = tmpDis;
                        targetObj = obs;
                    }

                }

                

                
               
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            //in_collider_num++;
           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            
            kill_target = other.gameObject;
            nearObj = serchTag(/*kill_target*/other.gameObject, "EscortTarget");
            tarret_switch_on = true;
        }
        


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            //in_collider_num--;
            nearObj = serchTag(/*kill_target*/other.gameObject, "EscortTarget");
            tarret_switch_on = false;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, start_rot_y, 0f));   //敵がいない場合は回転をリセット
            
        }
    }

    public void TarretLockOn()
    {
        //経過時間を取得
        searchTime += Time.deltaTime;

        if (searchTime >= 0.1f)
        {
            //最も近かったオブジェクトを取得
            //nearObj = serchTag(gameObject, "EscortTarget");

            //経過時間を初期化
            searchTime = 0;
        }

       

        if (nearObj == null)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, start_rot_y, 0f));   //敵がいない場合は回転をリセット
        }
        else
        {
            Debug.Log("near" + nearObj.name);
            //対象の位置の方向を向く
            transform.LookAt(nearObj.transform);

           transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));

            LesarSIghtLockOn();

                // transform.rotation = Quaternion.FromToRotation(transform.rotation, Quaternion.LookRotation(nearObj.transform.position - transform.position),120.0f * Time.deltaTime);

            //bullet.GetComponent<BoxCollider>().enabled = false;

                

            if (timeCount < 0)
            {
                Vector3 muzzle_pos = new Vector3(tarret_muzzle.transform.position.x, nearObj.transform.position.y, tarret_muzzle.transform.position.z);
               //使わない Vector3 tarret_rot = transform.rotation.eulerAngles;
                Vector3 near_pos= new Vector3(nearObj.transform.position.x, nearObj.transform.position.y, nearObj.transform.position.z);
                Vector3 test_rot = new Vector3(1f, 0f, 0f);

                //bullet.GetComponent<BoxCollider>().enabled = true;

                timeCount = span;

                Ray ray = new Ray(muzzle_pos, transform.TransformDirection(Vector3.forward) /*near_pos*//*new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)*/);

                Debug.DrawLine(muzzle_pos, /*ray.direction*/near_pos, UnityEngine.Color.red);
               

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("object"+hit.collider.gameObject.name);

                    //GameObject Bullet = Instantiate(BulletPrefab,hit.point, Quaternion.identity);
                    //Destroy(Bullet, 1.0f);
                    //Rayが当たったオブジェクトのtagがPlayerだったら
                    if (hit.collider.tag == "EscortTarget")
                    {
                      GameObject.FindGameObjectWithTag("SummonMachine").GetComponentInChildren<Summon_Insect>().spawn_count--;

                        Debug.Log("RayがPlayerに当たった");
                        Destroy(hit.collider.gameObject);
                        Debug.Log(hit.point);

                        SM.Play(SoundManager.SoundType.Incorrectans);

                    }
                    LS.lesar_fire_flag = true;
                    //hit_pos = hit.point;

                }
                

                // 敵の弾を生成する
                //GameObject Bullet = Instantiate(BulletPrefab, new Vector3(tarret_muzzle.transform.position.x, nearObj.transform.position.y+0.05f, tarret_muzzle.transform.position.z), Quaternion.identity);

                //Rigidbody BulletRb = Bullet.GetComponent<Rigidbody>();

                // 弾をforwardに飛ばす
                //BulletRb.AddForce(transform.forward * bulletSpeed);

                // ３秒後に弾を削除する。
                //Destroy(Bullet, 3.0f);
            }
        }
    }

    public void LesarSIghtLockOn()
    {
        Vector3 muzzle_pos2 = new Vector3(tarret_muzzle.transform.position.x, nearObj.transform.position.y, tarret_muzzle.transform.position.z);
        Ray ray2 = new Ray(muzzle_pos2, transform.TransformDirection(Vector3.forward) /*near_pos*//*new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)*/);
        RaycastHit hit2;
        if (Physics.Raycast(ray2, out hit2, 100f))
        {
            hit_pos = hit2.point;
        }
        Debug.DrawLine(muzzle_pos2, /*ray.direction*/hit_pos, UnityEngine.Color.red);
    }
    


}
