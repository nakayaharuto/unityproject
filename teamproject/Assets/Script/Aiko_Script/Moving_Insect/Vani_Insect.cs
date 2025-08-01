using UnityEngine;

public class Vani_Insect : MonoBehaviour
{
    [SerializeField] private Summon_Insect SI;
    [SerializeField] private SoundManager SM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SI=GameObject.FindGameObjectWithTag("SummonMachine").GetComponentInChildren<Summon_Insect>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("EscortTarget"))
        {
            Destroy(t);
            SI.spawn_count--;
        }
        SM.Play(SoundManager.SoundType.correctans);
    }

}
