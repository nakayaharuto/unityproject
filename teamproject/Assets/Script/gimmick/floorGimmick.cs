using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class floorGimmick : MonoBehaviour
{
    public GameObject floor;
    public bool flag=false;
   
    [SerializeField] private int rotate_count=4;


    private void OnMouseDown()
    {
        flag = true;

        if (rotate_count>0)
        {
            rotate_count--;
        }
        else
        {
            rotate_count = 4;
        }

        

    }

    public void Rotation_Floor()
    {
        if (floor.transform.rotation.eulerAngles.y>-rotate_count*90f&&flag==true)
        {
            floor.transform.Rotate(0f, 0.1f, 0f);
        }
        else
        {
            flag=false; 
        }


    }

    public void Update()
    {
        //Debug.Log(floor.transform.rotation.eulerAngles.y);

        Rotation_Floor();



    }


}
