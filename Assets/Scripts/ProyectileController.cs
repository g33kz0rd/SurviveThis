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

    private void Awake()
    {
        Debug.Log($"Is trigger: {transform.GetComponent<SphereCollider>().isTrigger}");
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

    private void OnTriggerEnter(Collider collider)
    {
        LogsController.Log($"Proyectile found an {collider.tag}");
        if (collider.CompareTag("Player"))
            return;

        var hp = collider.gameObject.GetComponent<HealthController>();
        hp.TakeDamage(proyectileInfo);

        EndLife();
    }
}
