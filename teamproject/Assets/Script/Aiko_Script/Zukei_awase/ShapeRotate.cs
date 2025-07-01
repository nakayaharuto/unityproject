using UnityEngine;

public class ShapeRotate : MonoBehaviour
{
    [SerializeField] public int random_num;
    public int rot_num=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random_num = Random.Range(1, 5);
        Debug.Log(this.name+random_num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (rot_num < 3)
        {
            rot_num++;
        }
        else
        {
            rot_num = 0;
        }
        this.gameObject.transform.eulerAngles = new Vector3(90f * -rot_num, 0f, 0f);
    }

}
