using UnityEngine;

public class AttackController : MonoBehaviour
{
    private GameObject projectileModel;
    private Transform projectileSpawn;
    private float currentCooldown = 0f;
    public WeaponInfo weaponInfo;

    private void Awake()
    {
        projectileModel = weaponInfo.ProyectileInfo.ProjectileModel;
        projectileSpawn = weaponInfo.ProyectileInfo.ProjectileSpawn;
    }

    public void Attack()
    {
        if (currentCooldown > 0)
            return;

        currentCooldown = weaponInfo.Cooldown;
        Spawnprojectile();
    }

    private void Spawnprojectile()
    {
        var projectile = Instantiate(projectileModel, projectileSpawn.position, projectileSpawn.rotation);
        var proyectileController = projectile.GetComponent<ProyectileController>();
        proyectileController.SetInfo(weaponInfo.ProyectileInfo);
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;
    }
}
