using UnityEngine;

public class Summon_Insect : MonoBehaviour
{
    public GameObject summon;
    public GameObject spawn_pos;
    [SerializeField,Header("0:x,1:y,2:z")] float[] pos_xyz;
    [SerializeField] public int spawn_count;
    [SerializeField] public int spawn_limit;
    [SerializeField] int spawn_cooltime;
    private GameObject summon_insect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos_xyz = new float[3];
        
    }

    // Update is called once per frame
    void Update()
    {
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
            summon_insect.GetComponent<Rigidbody>().useGravity = true;
           summon_insect.name=summon.name+spawn_count;
            spawn_count++;
            spawn_cooltime = 10;
        }
        
    }
}
