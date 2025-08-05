using UnityEngine;

public class Rot_Wall : MonoBehaviour
{
    [SerializeField] private GameObject rot_wall;
    [SerializeField] private float[] start_rot;
    [SerializeField] private bool rot_flag=true;
    [SerializeField,Header("‹È‚ª‚é•ûŒü")] private int wall_curve=0;
    [SerializeField] private Move_Insect MI;
    [SerializeField] private int plus_mainas;
    [SerializeField] private SoundManager SM;
    [SerializeField] private Renderer RC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_rot = new float[3];
        start_rot[0]=rot_wall.transform.rotation.eulerAngles.x;
        start_rot[1] = rot_wall.transform.rotation.eulerAngles.y;
        start_rot[2] = rot_wall.transform.rotation.eulerAngles.z;

        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        RC=this.GetComponent<Renderer>();
        rot_wall.GetComponent<Renderer>().material.color=RC.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnMouseDown()
    {
        if (rot_flag==true)
        {
            switch (wall_curve) 
            {
                case 0:
                    rot_wall.transform.localEulerAngles = new Vector3(start_rot[0] + 90f, 0, 0);
                    break;
                case 1:
                    rot_wall.transform.localEulerAngles = new Vector3(0, start_rot[1] + 90f, 0);
                    break;
                case 2:
                    rot_wall.transform.localEulerAngles = new Vector3(0,0 , start_rot[2] - 90f);
                    break;
            }
            
            rot_flag = false;
            SM.Play(SoundManager.SoundType.choice);
        }
        else
        {
            switch (wall_curve)
            {
                case 0:
                    rot_wall.transform.localEulerAngles = new Vector3(start_rot[0], 0, 0);
                    break;
                case 1:
                    rot_wall.transform.localEulerAngles = new Vector3(0, start_rot[1], 0);
                    break;
                case 2:
                    rot_wall.transform.localEulerAngles = new Vector3(0, 0, start_rot[2]);
                    break;
            }
            SM.Play(SoundManager.SoundType.Incorrectans);
            rot_flag = true;
        }



    }

}
