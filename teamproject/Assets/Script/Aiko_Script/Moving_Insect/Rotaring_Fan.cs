using UnityEngine;

public class Rotaring_Fan : MonoBehaviour
{
    public GameObject rotation_fan;

    private bool on_off_flag=false;

   [SerializeField]  private int rotation_limit;
    [SerializeField] private int limit;

    [SerializeField] private float start_rot_x;

    [SerializeField] private Renderer RS;
    [SerializeField] private SoundManager SM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RS=this.GetComponent<Renderer>();
        RS.material.color = this.GetComponent<Renderer>().material.color;
       
        start_rot_x =rotation_fan.transform.rotation.x;
        rotation_fan.GetComponentInChildren<Renderer>().material.color=this.GetComponent<Renderer>().material.color;
        Application.targetFrameRate = 120;
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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

            if (rotation_limit >= limit / 2)
            {
                if (rotation_limit % 80 > 40)
                {
                    RS.GetComponentInChildren<Renderer>().material.color = Color.red;
                }
                else
                {
                    RS.GetComponentInChildren<Renderer>().material.color = rotation_fan.GetComponentInChildren<Renderer>().material.color;
                    SM.Play(SoundManager.SoundType.correctans);
                }
            }
           else if (rotation_limit < limit / 2&& rotation_limit >= limit / 5)
            {
                if (rotation_limit % 40 >20)
                {
                    RS.GetComponentInChildren<Renderer>().material.color = Color.red;
                }
                else
                {
                    RS.GetComponentInChildren<Renderer>().material.color = rotation_fan.GetComponentInChildren<Renderer>().material.color;
                }
            }
            else if (rotation_limit < limit / 5)
            {
                if (rotation_limit % 20 > 10)
                {
                    RS.GetComponentInChildren<Renderer>().material.color = Color.red;
                }
                else
                {
                    RS.GetComponentInChildren<Renderer>().material.color = rotation_fan.GetComponentInChildren<Renderer>().material.color;
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
            SM.Play(SoundManager.SoundType.Pickup);
        }
       


    }

}
