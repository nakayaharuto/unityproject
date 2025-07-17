using UnityEngine;

public class Rotaring_Fan : MonoBehaviour
{
    public GameObject rotation_fan;

    private bool on_off_flag=false;

   [SerializeField]  private int rotation_limit;

    [SerializeField] private float start_rot_x;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_rot_x=rotation_fan.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (on_off_flag==true)
        {
            rotation_fan.transform.Rotate(Time.deltaTime*1000, 0.0f, 0.0f);
            rotation_limit--;
        }

        if (rotation_limit == 0)
        {
            on_off_flag = false;
            start_rot_x = 0.0f;
            rotation_fan.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
            
    }

    private void OnMouseDown()
    {
        if (on_off_flag==false)
        {
            on_off_flag = true;
            rotation_limit = 10000;
        }
       


    }

}
