using UnityEngine;

public class Lesar_Script : MonoBehaviour
{
    public GameObject Lesar_Ray;
    public float Lesar_Distance = 0.0f;
   
    public Lesar_Flag_Script LFS;

    public bool Fire_Flag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       LFS=this.GetComponentInChildren<Lesar_Flag_Script>();
        LFS.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log(LFS.Lesar_Flag);
    }

    // Update is called once per frame
    void Update()
    {
        if (LFS.Lesar_Flag==true&&Fire_Flag==true)
        {
            Lesar_Distance+=10f;
            Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance);
           // Lesar_Ray.transform.position=new Vector3(this.transform.position.x, this.transform.position.y, ((this.transform.position.z) - Lesar_Distance*0.3f) - 0.7f);
        }
        else
        {
           
        }


        
    }

   

}
