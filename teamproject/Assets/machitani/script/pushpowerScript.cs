using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class pushpowerScript : MonoBehaviour
{
    public float pushPower = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnContorllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb =hit .collider.attachedRigidbody;

        if(rb==null||rb.isKinematic)
        {
            return;
        }

        if(hit.moveDirection.y<-0.3f)
        {
            return;
        }
        Vector3 poushDir = new Vector3(hit.moveDirection.x, hit.moveDirection.z);

        //rb.velocity=pushDir*pushPower;
    }

}
