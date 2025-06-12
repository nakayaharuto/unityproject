using UnityEngine;
using System.Collections;
public class FadeController : MonoBehaviour
{
    public GameObject FadeImage;

    public float FadeDuration = 1.0f;
    public float FadeTimer = 0.0f;
    private bool IsFadeingIn = true;
    private bool IsFadeingOut = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(FadeImage == null)
        {
            Debug.Log("ê›íËÇ≥ÇÍÇƒÇ‹ÇπÇÒ");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
