using UnityEngine;

public class NumCheckiAnswer : MonoBehaviour
{
    public GameObject[] rotate_objects;
    ShapeRotate SR;
    public int true_flag=0;
    [SerializeField] private GameObject open_the_door;
    private bool CorrectFlag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (CorrectFlag==false)
        {
            true_flag = 0;

            for (int i = 0; i < rotate_objects.Length; i++)
            {
                SR = rotate_objects[i].GetComponent<ShapeRotate>();
                if (SR.random_num == SR.rot_num + 1)
                {
                    true_flag++;
                }




            }

            if (true_flag == 4)
            {
                
                open_the_door.SetActive(false);
                Debug.Log("Yes!");
            }
            else
            {
                Debug.Log("No!");
            }
        }
        

    }

}
