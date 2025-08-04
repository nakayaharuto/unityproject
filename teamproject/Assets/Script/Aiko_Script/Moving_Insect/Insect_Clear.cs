using UnityEngine;

public class Insect_Clear : MonoBehaviour
{
    public GameObject open_doors;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
        animator = open_doors.GetComponentInChildren<Animator>();
        animator.SetBool("open", false);
    }

}
