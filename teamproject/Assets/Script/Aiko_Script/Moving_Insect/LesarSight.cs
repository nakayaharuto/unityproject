using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LesarSight : MonoBehaviour
{
    [SerializeField] public bool lesar_fire_flag;
    [SerializeField] private GameObject lesar;
    [SerializeField] private Tarret TR;
    [SerializeField] private int stop_put;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TR=this.gameObject.GetComponentInParent<Tarret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lesar_fire_flag == true)
        {
            this.gameObject.transform.position = TR.hit_pos;

            //transform.position = Vector3.MoveTowards(this.transform.position, TR.hit_pos, 10.0f);

            //float tpp = TR.hit_pos.z;//当たった位置

            //if (TR.hit_pos.z<0.0f)
            //{
            //     tpp = -TR.hit_pos.z;
            //}

            //float ttp = TR.transform.position.z;//開始位置
            ////if (ttp < 0.0f)
            ////{
            ////    ttp = -ttp;
            ////}

            //Debug.Log("TR.hit_pos"+TR.transform.position.z);
            //Debug.Log("TPP" + tpp);

            //float lesar_num = ttp - tpp;
            //if (lesar_num<0.0f)
            //{
            //    lesar_num = -lesar_num;
            //}

            //int lesar_clone = (int)lesar_num*40;

            //foreach (GameObject item in GameObject.FindGameObjectsWithTag("LesarSight"))
            //{
            //    Destroy(item);
            //}

            //for (int i = 1; i <= lesar_clone; i++)
            //{
            //    //if (stop_put == 0)
            //    //{
            //        GameObject lesar_clone2 = Instantiate(lesar, new Vector3(TR.transform.position.x, TR.transform.position.y, TR.transform.position.z - i*0.05f), Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)), this.transform);
            //    //    stop_put = 1000;
            //    //}
            //    //stop_put--;

            //    Debug.Log("arfa"+i);

            //}



        }
        else
        {
            transform.position = new Vector3(0f,0f,0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("EscortTarget"))
        //{
        //    Destroy(other);
        //}

        //for (float i = TR.transform.position.z; i != TR.hit_pos.z; i+=100)
        //{

        //    GameObject lesar_clone=Instantiate(lesar,new Vector3(TR.transform.position.x,TR.transform.position.y,TR.transform.position.z+i), Quaternion.identity,this.transform.parent);

        //}
        Debug.Log("Collider");
        Debug.Log(other.name);
    }

    private void OnCollisionEnter(Collision other)
    {
        //for (float i = TR.transform.position.z; i != TR.hit_pos.z; i++)
        //{

        //    GameObject lesar_clone = Instantiate(lesar, new Vector3(TR.transform.position.x, TR.transform.position.y, TR.transform.position.z + i), Quaternion.identity, this.transform.parent);

        //}
        Debug.Log("Collision");
    }

    private void OnCollisionStay(Collision collision)
    {

        //for (float i = TR.transform.position.z; i != TR.hit_pos.z; i++)
        //{

        //    GameObject lesar_clone = Instantiate(lesar, new Vector3(TR.transform.position.x, TR.transform.position.y, TR.transform.position.z + i), Quaternion.identity, this.transform.parent);

        //}
        Debug.Log("Stay");
    }

}
