using System;
using UnityEngine;

[Serializable]
public class HealthData
{
    [field: SerializeField] public int MaxHealth { get; private set; }
}
