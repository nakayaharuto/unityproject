using UnityEngine;

public class Pushbox : MonoBehaviour
{
    public float Push = 5;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("box"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if(rb != null )
            {
                rb.AddForce(transform.forward * 10f);
            }
        }
    }
}
