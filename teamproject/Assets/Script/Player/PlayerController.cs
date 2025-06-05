using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動やらなんやら
    public float WalkSpeed = 3.0f;
    public float RanSpeed = 7.0f;
    public float Graviyty = -9.81f;
    public float JumpHeight = 2f;

    public float interactRange = 2f;
    public LayerMask itemLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //地面判定
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //移動入力
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //移動処理
        //controller.Move(move * WalkSpeed * Time.deltaTime);

        float dash = Input.GetKey(KeyCode.LeftShift) ? RanSpeed : WalkSpeed;


        controller.Move(move *  dash * Time.deltaTime);
        //ジャンプ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Graviyty);
        }
        //重力
        velocity.y += Graviyty * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Fキー入力
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractWithItem();
        }

    }
}
