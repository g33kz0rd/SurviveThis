using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public float healthPoints;
    public void DoDamage(ProyectileInfo proyectile)
    {
        healthPoints -= proyectile.Damage;

        if (healthPoints > 0)
            return;

        LogsController.Log($"{gameObject.name} died.");
    }
}
