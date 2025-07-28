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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("EscortTarget"))
    //    {
    //        TR.kill_target = other.gameObject;
    //        TR.nearObj = TR.serchTag(/*TR.kill_target*/other.gameObject, "EscortTarget");
    //        TR.TarretLockOn();
    //        LS.lesar_fire_flag = true;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            TR.kill_target = other.gameObject;
            TR.nearObj = TR.serchTag(/*TR.kill_target*/other.gameObject, "EscortTarget");
            TR.tarret_switch_on = true;
            //TR.TarretLockOn();
            LS.lesar_fire_flag = true;

            //if (TR.timeCount<0)
            //{
            //    TR.nearObj = TR.serchTag(other.gameObject, "EscortTarget");
            //    TR.TarretLockOn();
            //    LS.lesar_fire_flag = true;
            //    TR.timeCount=TR.span;
            //}



        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EscortTarget"))
        {
            TR.nearObj = TR.serchTag(/*kill_target*/other.gameObject, "EscortTarget");
            TR.nearObj = null;


            Tarret.transform.rotation = Quaternion.Euler(new Vector3(0f, Quaternion.identity.y, 0f)); ;   //“G‚ª‚¢‚È‚¢ê‡‚Í‰ñ“]‚ðƒŠƒZƒbƒg
            LS.lesar_fire_flag=false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        //TR.timeCount--;
    }
}
