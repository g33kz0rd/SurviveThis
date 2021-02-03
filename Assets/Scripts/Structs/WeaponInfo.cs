using System;
using UnityEngine;

[Serializable]
public struct WeaponInfo
{
    [SerializeField]
    private bool enabled;
    public bool Enabled { get => enabled; }

    [SerializeField]
    private float cooldown;
    public float Cooldown { get => cooldown; }

    [SerializeField]
    private ProyectileInfo proyectileInfo;

    public GameObject Owner
    {
        get { return proyectileInfo.Owner; }
        set { proyectileInfo.Owner = value; }
    }

    public ProyectileInfo ProyectileInfo { get => proyectileInfo; private set => proyectileInfo = value; }
}