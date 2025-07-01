using UnityEngine;
using UnityEngine.UI;


public class MonitorText : MonoBehaviour
{
    //public GameObject Monitor;
    public Text moni_text;
    private int[] appear_num;
    ShapeRotate SR;
    NumCheckiAnswer NCA;
    public GameObject[] rl_buttons;
    [SerializeField]private int button_num=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NCA=GameObject.FindGameObjectWithTag("Respawn").GetComponent<NumCheckiAnswer>();

        for (int i = 0; i < 4; i++)
        {
            SR = NCA.rotate_objects[i].GetComponent<ShapeRotate>();
            
            
            
            //Debug.Log("bbbb" + SR.name);
            //Debug.Log(SR.random_num);
            //appear_num[i] = SR.random_num;
            //Debug.Log("aaaaaa"+appear_num[i]);
           

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
