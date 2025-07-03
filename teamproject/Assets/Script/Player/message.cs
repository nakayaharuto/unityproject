using UnityEngine;
using UnityEngine.UI;

public class message : MonoBehaviour
{
    [SerializeField] Text DesplayText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DesplayText != null)
        {
            DesplayText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(DesplayText != null)
            {
                DesplayText.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (DesplayText != null)
            {
                DesplayText.enabled = false;
            }
        }
    }
}
