using UnityEngine;

public class Move_Clane : MonoBehaviour
{
    Vector3 StartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float posY = StartPos.y + Mathf.Sin(Time.time) * 4;
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("lll");

        if (other.gameObject.CompareTag("box"))
        {
            //this.transform.SetParent(other.transform.parent);

            other.transform.position= new Vector3(this.transform.position.x,this.transform.position.y , this.transform.position.z);

            Debug.Log("abcdefg");
        }


    }
}
