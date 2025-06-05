using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool is_playable;
    public static GameManager instance;

    public GameObject mainImage;
    public enum PlayerState
    {
        normal,
        talking,
        choosing,
        pausing,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
