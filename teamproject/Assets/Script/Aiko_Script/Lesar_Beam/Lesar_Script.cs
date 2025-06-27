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
        if (LFS.Lesar_Flag==true&&Fire_Flag==true||LFS.Lesar_Flag==true&&LFS.Lesar_Enable==true)
        {
            Lesar_Distance+=3f;
            Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance);
           // Lesar_Ray.transform.position=new Vector3(this.transform.position.x, this.transform.position.y, ((this.transform.position.z) - Lesar_Distance*0.3f) - 0.7f);
        }
        else if (Fire_Flag==false)
        {
            Lesar_Distance = 0f;
            Lesar_Ray.transform.localScale = new Vector3(0.5f, 0.5f, Lesar_Distance);
        }


        
    }

    public void OnMouseDown()
    {
        if (Fire_Flag==true)
        {
            Fire_Flag = false;

            foreach (GameObject LS in GameObject.FindGameObjectsWithTag("Crane"))
            {
                Debug.Log(LS.name);
                LS.GetComponent<Lesar_Script>().Fire_Flag = false;
                LS.GetComponent<Lesar_Script>().LFS.Lesar_Enable = false;
            }

        }
        else
        {
            Fire_Flag = true;
            LFS.Lesar_Flag = true;
        }

        Debug.Log(Fire_Flag);

    }


}
