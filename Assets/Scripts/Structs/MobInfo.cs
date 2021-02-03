using System;
using UnityEngine;

[Serializable]
public struct MobInfo
{
    [SerializeField]
    private float health;
    [SerializeField]
    private long experienceWorth;
    public float Health { get => health; }
    public long Experience { get => experienceWorth; }
}