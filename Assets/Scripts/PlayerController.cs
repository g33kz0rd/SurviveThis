using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public GameObject cameraContainer;
    public float speed = 10;

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

        characterController.Move(movement.normalized * speed * Time.deltaTime);

        transform.Rotate(transform.up, Input.GetAxis("Mouse X"));

        cameraContainer.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -1);

        var angX = cameraContainer.transform.localEulerAngles.x > 180 ? cameraContainer.transform.localEulerAngles.x - 360 : cameraContainer.transform.localEulerAngles.x;
        angX = Mathf.Clamp(angX, -36, 50);
        cameraContainer.transform.localEulerAngles = Vector3.right * angX;
    }
}
