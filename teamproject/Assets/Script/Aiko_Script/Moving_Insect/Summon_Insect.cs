using UnityEngine;
using UnityEngine.UI;

public class Summon_Insect : MonoBehaviour
{
    public GameObject summon;
    public GameObject spawn_pos;
    [SerializeField,Header("0:x,1:y,2:z")] float[] pos_xyz;
    [SerializeField] public int spawn_count;
    [SerializeField] public int spawn_limit;
    [SerializeField] int spawn_cooltime;
    private GameObject summon_insect;
    [SerializeField] private SoundManager SM;

    [SerializeField] private GameObject monitor;
    [SerializeField] private Text txt;
    [SerializeField]private int spawn_rot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos_xyz = new float[3];
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        txt = monitor.GetComponentInChildren<Text>();
        txt.text = "この近辺に偵察機はいません。";
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("EscortTarget"))
        {
            if (spawn_count>0)
            {
                txt.text = "現在の偵察機の数" + spawn_count + "体";
            }
            else
            {
                txt.text = "この近辺に偵察機はいません。";
            }



        }

        if (spawn_cooltime>=0)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            spawn_cooltime--;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

    private void OnMouseDown()
    {
        if (spawn_count<spawn_limit&&spawn_cooltime<0)
        {
           summon_insect= Instantiate(summon, new Vector3(spawn_pos.transform.position.x + pos_xyz[0], spawn_pos.transform.position.y + pos_xyz[1], spawn_pos.transform.position.z + pos_xyz[2]), Quaternion.identity) as GameObject;
            Debug.Log("summon_insect" + summon_insect.transform.localEulerAngles.y);
            //float test=90f*spawn_rot;
            

            //X軸基準に+5°の回転を生成し、クォータニオンに変換
            //Quaternion rotation5 = Quaternion.Euler(0, 90*spawn_rot, 0);

            //クォータニオンで回転を実行してオブジェクトに適用
            //summon_insect.transform.rotation = rotation5;
             summon_insect.transform.localEulerAngles= new Vector3(0, 90f * spawn_rot, 0);
            Debug.Log("summon_insect" + summon_insect.transform.localEulerAngles.y);
            summon_insect.GetComponent<Rigidbody>().useGravity = true;
           summon_insect.name=summon.name+spawn_count;
            spawn_count++;
            spawn_cooltime = 10;
        }
        SM.Play(SoundManager.SoundType.Pickup);
    }
}
