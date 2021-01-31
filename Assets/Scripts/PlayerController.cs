using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    public GameObject cameraContainer;
    public float speed = 10;
    public float jumpSpeed = 8;
    public float gravity = 20;
    private float jumpStatus = 0;
    private const int MAX_JUMPS = 2;
    private int jumpsLeft = 0;
    public float dashSpeed = 80;
    public float dashPushback = 200;
    private float dashStatus = 0;
    private Vector3 dashDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movement += transform.forward;
        if (Input.GetKey(KeyCode.S))
            movement -= transform.forward;

        if (Input.GetKey(KeyCode.D))
            movement += transform.right;
        if (Input.GetKey(KeyCode.A))
            movement -= transform.right;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashStatus = dashSpeed;
            dashDirection = movement;
        }
        dashStatus -= dashPushback * Time.deltaTime;

        if (dashStatus < 0)
            dashStatus = 0;

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

        characterController.Move(movement.normalized * speed * Time.deltaTime + transform.up * jumpStatus * Time.deltaTime + dashDirection * dashStatus * Time.deltaTime);

        transform.Rotate(transform.up, Input.GetAxis("Mouse X"));

        cameraContainer.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -1);

        var angX = cameraContainer.transform.localEulerAngles.x > 180 ? cameraContainer.transform.localEulerAngles.x - 360 : cameraContainer.transform.localEulerAngles.x;
        angX = Mathf.Clamp(angX, -36, 50);
        cameraContainer.transform.localEulerAngles = Vector3.right * angX;
    }
}
