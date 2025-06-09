using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SwitchScript : MonoBehaviour
{
    float bottomY = -0.1f;
    float speed = 0.5f;
    private Animator animator;

    bool active;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && transform.position.y > bottomY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            animator.SetBool("open", !animator.GetBool("open"));
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!active&&other.CompareTag("box"))
        {
            active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        active=false;
    }
}
