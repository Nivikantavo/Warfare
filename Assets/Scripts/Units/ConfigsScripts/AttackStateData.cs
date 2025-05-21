using System;
using UnityEngine;

[Serializable]
public class AttackStateData
{
    [field: SerializeField] public float Damage {  get; private set; }
    [field: SerializeField] public float AttackCooldown { get; private set; }
    [field: SerializeField, Range(1, 2)] public float AttackSpeed { get; private set; }
}
