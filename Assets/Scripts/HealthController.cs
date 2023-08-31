using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public float healthPoints;
    public void TakeDamage(ProyectileInfo proyectile)
    {
        healthPoints -= proyectile.Damage;

        if (healthPoints > 0)
            return;

        EndLife();
    }

    private void EndLife()
    {
        Destroy(gameObject);
    }
}
