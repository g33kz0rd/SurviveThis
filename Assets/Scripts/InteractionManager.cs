using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        LogsController.Log(collision.gameObject.name);
    }
}
