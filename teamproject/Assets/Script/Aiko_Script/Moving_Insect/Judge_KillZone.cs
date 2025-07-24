using UnityEngine;

public class Judge_KillZone : MonoBehaviour
{
    [SerializeField] public GameObject Tarret;
    public Tarret TR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TR=Tarret.GetComponent<Tarret>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            TR.nearObj = TR.serchTag(gameObject, "EscortTarget");
            TR.TarretLockOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            Tarret.transform.rotation = Quaternion.Euler(new Vector3(0f, Quaternion.identity.y, 0f)); ;   //“G‚ª‚¢‚È‚¢ê‡‚Í‰ñ“]‚ğƒŠƒZƒbƒg
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
