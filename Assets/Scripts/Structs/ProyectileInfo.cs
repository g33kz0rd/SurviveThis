using System;
using UnityEngine;

[Serializable]
public struct ProyectileInfo
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float life;
    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private GameObject bulletModel;
    [SerializeField]
    private Transform bulletSpawn;

    public float Speed { get => speed; }
    public float Life { get => life; }
    public float SpawnDelay { get => spawnDelay; }
    public GameObject BulletModel { get => bulletModel; }
    public Transform BulletSpawn { get => bulletSpawn; }
    public float Damage { get => damage; }
    public GameObject Owner { get; set; }
}