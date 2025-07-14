using UnityEngine;

public class Lesar_Clear : MonoBehaviour
{
    public bool lesar_clear=false;
    public GameObject[] open_doors;
    public Animator[] animator;
    [SerializeField] private SoundManager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
        animator = new Animator[open_doors.Length];
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {
        if (lesar_clear==true)
        {
            this.GetComponent<Renderer>().material.color = Color.green;

            for (int i = 0; i < open_doors.Length; i++)
            {
                animator[i] = open_doors[i].GetComponentInChildren<Animator>();
                animator[i].SetBool("open", false);
                Debug.Log(animator[i].name + i);
            }

            lesar_clear = false;
            SM.Play(SoundManager.SoundType.correctans); //サウンドマネージャーを使用して効果音再生
        }
        else 
        {
            this.GetComponent<Renderer>().material.color = Color.red;

            for (int i = 0; i < open_doors.Length; i++)
            {
                animator[i] = open_doors[i].GetComponentInChildren<Animator>();
                animator[i].SetBool("open", true);
                Debug.Log(animator[i].name + i);
            }

            lesar_clear = true;
        }


        


    }

}
