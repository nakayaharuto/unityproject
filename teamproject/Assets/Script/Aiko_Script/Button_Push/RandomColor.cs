using UnityEngine;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private int[] rand_color_num;
    [SerializeField] public GameObject[] color_objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            rand_color_num[i] = Random.Range(0, 3);

            switch(rand_color_num[i])
            {
                case 0:
                    color_objects[i].GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    color_objects[i].GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 2:
                    color_objects[i].GetComponent<Renderer>().material.color = Color.yellow;
                    break;


            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
