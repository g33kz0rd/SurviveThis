
using System;
using UnityEngine;

public class ActionsController : MonoBehaviour
{
    public GameObject interactiveBox;

    void Update()
    {
        if(Input.GetKey(KeyCode.G))
            Grab();

        if (Input.GetKey(KeyCode.E))
            Interact();

        if (Input.GetMouseButton(0))
            UseEquipedItem();
    }

    private void UseEquipedItem()
    {
        LogsController.Log("ActionsController.UseEquipedItem");
    }

    private void Interact()
    {
        LogsController.Log("ActionsController.Interact");
    }

    private void Grab()
    {
        LogsController.Log("ActionsController.Grab");
    }
}
