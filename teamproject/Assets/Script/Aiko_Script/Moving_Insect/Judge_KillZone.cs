using UnityEngine;

public class Judge_KillZone : MonoBehaviour
{
    [SerializeField] public GameObject Tarret;
    public Tarret TR;
    [SerializeField] private LesarSight LS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TR=Tarret.GetComponent<Tarret>();
        LS=Tarret.GetComponentInChildren<LesarSight>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            TR.nearObj = TR.serchTag(other.gameObject, "EscortTarget");
            TR.TarretLockOn();
            LS.lesar_fire_flag = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            Tarret.transform.rotation = Quaternion.Euler(new Vector3(0f, Quaternion.identity.y, 0f)); ;   //“G‚ª‚¢‚È‚¢ê‡‚Í‰ñ“]‚ğƒŠƒZƒbƒg
            LS.lesar_fire_flag=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
