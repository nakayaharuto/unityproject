using UnityEngine;

public class Rot_Wall_not_Button : MonoBehaviour
{
    [SerializeField] private Move_Insect MI;
    [SerializeField] private bool plus_mainas;
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
            MI = collision.gameObject.GetComponent<Move_Insect>();
            if (plus_mainas==true)
            {
                MI.rot_plus_mainas = -1;
                

            }else
            {
                MI.rot_plus_mainas = 1;
            }
        }
    }

}
