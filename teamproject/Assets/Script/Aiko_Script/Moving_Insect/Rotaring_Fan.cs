using UnityEngine;

public class Rotaring_Fan : MonoBehaviour
{
    public GameObject rotation_fan;

    private bool on_off_flag=false;

   [SerializeField]  private int rotation_limit;
    [SerializeField] private int limit;

    [SerializeField] private float start_rot_x;

    [SerializeField] private Renderer RS;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RS=this.GetComponent<Renderer>();
        RS.material.color = this.GetComponent<Renderer>().material.color;
       
        start_rot_x =rotation_fan.transform.rotation.x;
        rotation_fan.GetComponentInChildren<Renderer>().material.color=this.GetComponent<Renderer>().material.color;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (on_off_flag==true)
        {
            start_rot_x = 0.0f;
            rotation_fan.transform.localEulerAngles = new Vector3(180.0f, 0.0f, 0.0f);
            this.GetComponent<Renderer>().material.color = Color.red;
            rotation_limit--;

            if (rotation_limit < limit / 10)
            {
                if (rotation_limit % 2== 0)
                {
                    RS.GetComponentInChildren<Renderer>().material.color = Color.red;
                }
                else
                {
                    RS.GetComponentInChildren<Renderer>().material.color = RS.material.color;
                }


            }

        }

        if (rotation_limit == 0)
        {
            on_off_flag = false;
            rotation_fan.transform.Rotate(Time.deltaTime * 2000, 0.0f, 0.0f);
            
            this.GetComponent<Renderer>().material.color = rotation_fan.GetComponentInChildren<Renderer>().material.color;
            
        }

        

    }

    private void OnMouseDown()
    {
        if (on_off_flag==false)
        {
            on_off_flag = true;
            rotation_limit = limit;
        }
       


    }

}
