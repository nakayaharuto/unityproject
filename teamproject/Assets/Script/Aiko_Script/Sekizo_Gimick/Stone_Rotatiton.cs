using UnityEngine;

public class Stone_Rotatiton : MonoBehaviour
{
    public int rot_num_stone;
    public int rannum_true_stone;
    [SerializeField] private SoundManager SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rannum_true_stone = Random.Range(0,4);
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (rot_num_stone < 3)
        {
            rot_num_stone++;
        }
        else
        {
            rot_num_stone = 0;
        }
        this.gameObject.transform.eulerAngles = new Vector3(0f, 90f * rot_num_stone, 0f);
        SM.Play(SoundManager.SoundType.choice); //サウンドマネージャーを使用して効果音再生
    }

}
