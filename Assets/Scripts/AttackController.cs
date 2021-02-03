using UnityEngine;

public class AttackController : MonoBehaviour
{
    private GameObject bulletModel;
    private Transform bulletSpawn;
    private float currentCooldown = 0f;
    public WeaponInfo weaponInfo;

    private void Awake()
    {
        bulletModel = weaponInfo.ProyectileInfo.BulletModel;
        bulletSpawn = weaponInfo.ProyectileInfo.BulletSpawn;
    }

    public void Attack()
    {
        if (currentCooldown > 0)
            return;

        currentCooldown = weaponInfo.Cooldown;
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletModel, bulletSpawn.position, bulletSpawn.rotation);
        var proyectileController = bullet.AddComponent<ProyectileController>();
        proyectileController.SetInfo(weaponInfo.ProyectileInfo);
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0))
            Attack();
    }
}
