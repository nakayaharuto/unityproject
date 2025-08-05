using UnityEngine;

public class Insect_Clear : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        animator = open_doors.GetComponentInChildren<Animator>();
        animator.SetBool("open", false);
        SM.Play(SoundManager.SoundType.correctans);
    }

}
