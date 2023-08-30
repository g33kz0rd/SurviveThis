using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerHandler : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 nextMovement;

    public bool IsGrounded { get; private set; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        characterController.Move(nextMovement * Time.deltaTime);
        IsGrounded = characterController.isGrounded;
        nextMovement = Vector3.zero;
    }

    internal void Move(Vector3 vector3)
    {
        nextMovement += vector3;
    }
}
