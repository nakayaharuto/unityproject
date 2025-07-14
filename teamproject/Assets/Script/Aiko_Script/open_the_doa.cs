using UnityEngine;

public class open_the_doa : MonoBehaviour
{
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
        animator = open_doors.GetComponentInChildren<Animator>();
        animator.SetBool("open", false);
        this.GetComponent<Renderer>().material.color = Color.green;
        SM.Play(SoundManager.SoundType.Incorrectans); //サウンドマネージャーを使用して効果音再生
    }
}
