using System;
using UnityEngine;

[Serializable]
public class AttackStateData
{
    [field: SerializeField] public float Damage {  get; private set; }
    [field: SerializeField] public float TimeBetweenAttack { get; private set; }
}
