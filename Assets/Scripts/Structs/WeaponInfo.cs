using System;
using UnityEngine;

[Serializable]
public struct WeaponInfo
{
    [SerializeField]
    private float cooldown;
    public float Cooldown { get => cooldown; }

    [SerializeField]
    private ProyectileInfo proyectileInfo;

    public ProyectileInfo ProyectileInfo { get => proyectileInfo; private set => proyectileInfo = value; }
}