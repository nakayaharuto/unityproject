using UnityEngine;

public class Teleport_Insect : MonoBehaviour
{
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject exit;
    [SerializeField] private int escort_rot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entrance = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscortTarget"))
        {
            other.GetComponent<Move_Insect>().rot_num = escort_rot;
            other.transform.position = exit.transform.position;
            other.transform.localEulerAngles = new Vector3(0, 90f * escort_rot, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
