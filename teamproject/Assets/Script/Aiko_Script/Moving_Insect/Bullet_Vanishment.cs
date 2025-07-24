using UnityEngine;

public class Bullet_Vanishment : MonoBehaviour
{
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
        this.GetComponent<ParticleSystem>().Play();
        Destroy(this);

        if (collision.gameObject.CompareTag("EscortTarget"))
        {
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            Destroy(other.gameObject);
        }
    }

}
