using System;
using UnityEngine;

[Serializable]
public class HealthData
{
    [field: SerializeField] public float MaxHealth { get; private set; }
}
