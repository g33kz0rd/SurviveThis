using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    private ProyectileInfo proyectileInfo;

    private float currentLife;

    public void SetInfo(ProyectileInfo proyectileInfo)
    {
        this.proyectileInfo = proyectileInfo;
        currentLife = proyectileInfo.Life;
    }

    private void Update()
    {
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
                if (cp.otherCollider.CompareTag("Enemy"))
                    continue;

                var hp = cp.otherCollider.gameObject.GetComponent<HealthController>();
                hp.DoDamage(proyectileInfo);
                break;
            }
        }

        EndLife();
    }
}
