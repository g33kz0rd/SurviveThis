using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpSpeed = 8;
    public float gravity = 20;
    private float jumpStatus = 0;
    private const int MAX_JUMPS = 2;
    private int jumpsLeft = 0;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();        
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            jumpStatus = 0;
            jumpsLeft = MAX_JUMPS;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (characterController.isGrounded || jumpsLeft > 0))
        {
            jumpsLeft--;
            jumpStatus = jumpSpeed;
        }

        jumpStatus -= gravity * Time.deltaTime;

        characterController.Move(transform.up * jumpStatus * Time.deltaTime);

    }
}
