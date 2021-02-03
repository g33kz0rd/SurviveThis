using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    private ProyectileInfo proyectileInfo;

    private float currentLife;
    private float spawnDelay;

    public void SetInfo(ProyectileInfo proyectileInfo)
    {
        this.proyectileInfo = proyectileInfo;
        currentLife = proyectileInfo.Life;
        spawnDelay = proyectileInfo.SpawnDelay;
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;

        if (spawnDelay > 0)
            return;

        currentLife -= Time.deltaTime;

        if (currentLife < 0)
        {
            EndLife();
            return;
        }

        transform.position = transform.position + transform.forward * proyectileInfo.Speed * Time.deltaTime;
    }

    private void EndLife()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        List<ContactPoint> cps = new List<ContactPoint>();

        collision.GetContacts(cps);

        foreach(var cp in cps)
        {
            if (cp.otherCollider != null)
            {
                LogsController.Log($"Proyectile found: {cp.otherCollider.tag}");
                if (cp.otherCollider.tag != "Enemy")
                    continue;

                var hp = cp.otherCollider.gameObject.GetComponent<HealthController>();
                hp.DoDamage(proyectileInfo);
                break;
            }
        }

        EndLife();
    }
}
