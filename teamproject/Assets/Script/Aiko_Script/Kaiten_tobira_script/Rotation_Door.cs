using UnityEngine;

public class Rotation_Door : MonoBehaviour
{
    public GameObject RotateDoor;
    public bool switch_flag = false;
    private int switch_on_off=0;
    public float limit_rotate;
    private float first_rot;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.green;
        first_rot = RotateDoor.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (switch_flag==false/*switch_on_off==-1*/)//off
        {
            if (RotateDoor.transform.rotation.y<=first_rot)
            {
                RotateDoor.transform.Rotate(0f, /*limit_rotate * Time.deltaTime*/0.2f, 0f);
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Renderer>().material.color = Color.red;
                //Debug.Log(RotateDoor.transform.rotation.y);
            }
            else
            {
                RotateDoor.transform.Rotate(0f, 0f, 0f);
                switch_on_off = 0;
                switch_flag = false;
                this.GetComponent<BoxCollider>().enabled = true;
                this.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else if (switch_flag==true)//on
        {
            if (RotateDoor.transform.rotation.y >= -limit_rotate)
            {
                RotateDoor.transform.Rotate(0f, /*-limit_rotate * Time.deltaTime*/-0.2f, 0f);
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                RotateDoor.transform.Rotate(0f, 0f, 0f);
                switch_on_off = 0;
                switch_flag = true;
                this.GetComponent<BoxCollider>().enabled = true;
                this.GetComponent<Renderer>().material.color = Color.green;
            }

        }
        else
        {
            RotateDoor.transform.Rotate(0f, 0f, 0f);
        }


    }

    private void OnMouseDown()
    {
                if (switch_flag==true)
                {
            switch_flag = false;
                    //switch_on_off = -1;
                }
                else
                {
            switch_flag = true;
                    //switch_on_off = 1;
                }

               
        

        

       

    }

}
