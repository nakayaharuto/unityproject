using UnityEngine;

public class Answer_Stone_Gimick : MonoBehaviour
{
    public GameObject[] stones;
    [SerializeField] private bool stone_clear_flag;
    [SerializeField] private int stone_clear_count=0;
    [SerializeField] private Stone_Rotatiton[] SR;
    private Renderer Ren;
    public GameObject open_doors;
    public Animator animator;
    [SerializeField] private SoundManager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ren = this.GetComponent<Renderer>();
        SR = new Stone_Rotatiton[stones.Length];

        for (int i = 0; i < stones.Length; i++)
        {
            
            SR[i] = stones[i].GetComponent<Stone_Rotatiton>();
        }
        Ren.material.color = Color.red;
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < stones.Length; i++)
        {
            if (SR[i].rot_num_stone == SR[i].rannum_true_stone)
            {
                stone_clear_count++;
            }

        }

        if (stone_clear_count==stones.Length)
        {
            stone_clear_flag = true;
            Debug.Log("HellGuast");
            stone_clear_count = 0;
           Ren.material.color = Color.green;
            animator = open_doors.GetComponentInChildren<Animator>();
            animator.SetBool("open", false);
            SM.Play(SoundManager.SoundType.correctans); //サウンドマネージャーを使用して効果音再生
        }
        else
        {
            stone_clear_count = 0;
            SM.Play(SoundManager.SoundType.Incorrectans); //サウンドマネージャーを使用して効果音再生
            Debug.Log("fffffffalse");
        }


    }

}
