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
    private GameObject projectileModel;
    [SerializeField]
    private Transform projectileSpawn;
    [SerializeField]
    private string target;

    public float Speed { get => speed; }
    public float Life { get => life; }
    public float SpawnDelay { get => spawnDelay; }
    public GameObject ProjectileModel { get => projectileModel; }
    public Transform ProjectileSpawn { get => projectileSpawn; }
    public float Damage { get => damage; }
    public string Target { get => target; }
}