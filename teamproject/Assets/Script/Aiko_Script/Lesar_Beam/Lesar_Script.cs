using UnityEngine;

public class Lesar_Script : MonoBehaviour
{
    public GameObject Lesar_Ray;
    public float Lesar_Distance = 0.0f;
    public float StartPos = 0.0f;
    public Lesar_Flag_Script LFS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       LFS=this.GetComponentInChildren<Lesar_Flag_Script>();
        Debug.Log(LFS.Lesar_Flag);
    }

    // Update is called once per frame
    void Update()
    {
        if (LFS.Lesar_Flag==true)
        {
            Lesar_Distance+=0.01f;
        }
        

            Lesar_Ray.transform.localScale = new Vector3(1.0f, 1.0f, Lesar_Distance);
        //Lesar_Ray.transform.position= new Vector3(0.0f, 0.0f, Lesar_Distance);
    }

   

}
