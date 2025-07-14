using UnityEngine;

public class NumCheckiAnswer : MonoBehaviour
{
    public GameObject[] rotate_objects;
   public ShapeRotate SR;
    public int true_flag=0;
    [SerializeField] private GameObject open_the_door;
    private bool CorrectFlag = false;
    public GameObject open_doors;
    public Animator animator;
    [SerializeField] private SoundManager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (CorrectFlag==false)
        {
            true_flag = 0;

            for (int i = 0; i < rotate_objects.Length; i++)
            {
                SR = rotate_objects[i].GetComponent<ShapeRotate>();
                if (SR.random_num == SR.rot_num)
                {
                    true_flag++;
                }




            }

            if (true_flag == 4)
            {
                for (int i = 0; i < rotate_objects.Length; i++)
                {
                    SR = rotate_objects[i].GetComponent<ShapeRotate>();

                    SR.GetComponent<Renderer>().material.color = Color.green;
                    SR.GetComponent<BoxCollider>().enabled = false;
                    

                }
                this.GetComponent<BoxCollider>().enabled = false;
                //open_the_door.SetActive(false);

                animator = open_doors.GetComponentInChildren<Animator>();
                animator.SetBool("open", false);
                SM.Play(SoundManager.SoundType.correctans); //サウンドマネージャーを使用して効果音再生
                Debug.Log("Yes!");
            }
            else
            {
                SM.Play(SoundManager.SoundType.Incorrectans); //サウンドマネージャーを使用して効果音再生
                Debug.Log("No!");
            }
        }
        

    }

}
