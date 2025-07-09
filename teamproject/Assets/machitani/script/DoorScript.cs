using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    //ドアエリアに入ってるかどうか
    private bool isNear;
    //ドアアニメーター
    private Animator animator;

    //サウンドマネージャー
    [SerializeField] private SoundManager soundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isNear = false;
        animator=transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")&&isNear)
        {
            animator.SetBool("open",!animator.GetBool("open"));
            soundManager.Play(SoundManager.SoundType.Open); //サウンドマネージャーを使用して効果音再生
        }
    }
     void OnTriggerEnter(Collider col)
    {
       if(col.tag=="Player")
        {
            isNear=true;
            
        }
    }
     void OnTriggerExit(Collider col)
    {
        if(col.tag=="Player")
        {
            isNear=false;
        }
    }
}
