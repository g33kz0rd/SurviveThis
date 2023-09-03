using UnityEngine;

public class DashController : MonoBehaviour
{
    public float dashSpeed = 40;
    public float dashPushback = 200;
    private float dashStatus = 0;
    private Vector3 dashDirection;
    private CharacterControllerHandler characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterControllerHandler>();
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

        characterController.Move(dashDirection * dashStatus);
    }
}
