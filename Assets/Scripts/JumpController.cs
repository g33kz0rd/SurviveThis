using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpSpeed = 8;
    public float gravity = 20;
    private float jumpStatus = 0;
    private const int MAXJUMPS = 2;
    private int jumpsLeft = 0;
    private CharacterControllerHandler characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterControllerHandler>();        
    }

    void Update()
    {
        LogsController.Log($"Grounded: {characterController.IsGrounded}");

        if (characterController.IsGrounded)
        {
            jumpStatus = 0;
            jumpsLeft = MAXJUMPS;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (characterController.IsGrounded || jumpsLeft > 0))
        {
            jumpsLeft--;
            jumpStatus = jumpSpeed;
        }

        jumpStatus -= gravity * Time.deltaTime;

        characterController.Move(transform.up * jumpStatus);

    }
}
