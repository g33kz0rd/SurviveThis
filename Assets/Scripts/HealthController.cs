using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public event EventHandler<OnDeadEventArgs> OnDead;

    [SerializeField]
    public float MaxHealth;
    private float healthPoints;

    private void OnEnable()
    {
        healthPoints = MaxHealth;
    }

    public void TakeDamage(ProyectileInfo proyectile)
    {
        healthPoints -= proyectile.Damage;

        if (healthPoints > 0)
            return;

        OnDead?.Invoke(this, new OnDeadEventArgs() { gameObject = gameObject, healthPoints = healthPoints });
    }
}

public class OnDeadEventArgs
{
    public GameObject gameObject;
    public float healthPoints;
}