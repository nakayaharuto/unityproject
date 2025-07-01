using UnityEngine;

public class Pushbox : MonoBehaviour
{
    public float Push = 5;
    public float rayDistance = 2f;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//プレイヤー自身のrb
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Rigidbody hitRb = hit.collider.attachedRigidbody;

                if (hitRb != null && !hitRb.isKinematic)
                {
                    hitRb.AddForce(transform.forward * Push, ForceMode.Force);
                }
            }

            transform.position += transform.forward * Time.deltaTime * 2f;
        }
    }

}
