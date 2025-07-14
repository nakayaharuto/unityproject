using UnityEngine;
using UnityEngine.UI;

public class ShapeRotate : MonoBehaviour
{
    [SerializeField] public int random_num;
    public int rot_num=0;
    public Text text;
    [SerializeField] private SoundManager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random_num = Random.Range(1, 10);
        Debug.Log(this.name+random_num);
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (rot_num < 9)
        {
            rot_num++;
        }
        else
        {
            rot_num = 0;
        }
        //this.gameObject.transform.eulerAngles = new Vector3(90f * -rot_num, 0f, 0f);
        text.text = ""+rot_num;
        SM.Play(SoundManager.SoundType.choice); //サウンドマネージャーを使用して効果音再生
    }

}
