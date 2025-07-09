using UnityEngine;
using UnityEngine.UI;

public class operation : MonoBehaviour
{
    float Limit = 10f;//制限時間
    float now = 0f;//経過時間
    public Slider TimerGauge;//残り時間

    [SerializeField] GameObject panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間制限
        now += Time.deltaTime;//タイマー
        float t = now / Limit;
        TimerGauge.value = Mathf.Lerp(1f,0f,t);
        float timelimit = Limit - now;//のこり時間
        timelimit = Mathf.Max(timelimit, 0f);
        string timeLog = timelimit.ToString("0f");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            TimerGauge.value = 1f;//制限時間ゲージ
        }
    }

}
