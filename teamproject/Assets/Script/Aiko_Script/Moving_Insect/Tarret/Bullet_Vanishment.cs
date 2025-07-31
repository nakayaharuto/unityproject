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
        if (collision.gameObject.CompareTag("EscortTarget"))
        {
            Destroy(collision.gameObject);
            
        }

        this.GetComponent<ParticleSystem>().Play();
       
        Destroy(this.gameObject);

        if (collision.gameObject.CompareTag("EscortTarget"))
        {
            Destroy(collision.gameObject);
        }

        Debug.Log("hit+" + collision.gameObject.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            Destroy(other.gameObject);
        }
    }

}
