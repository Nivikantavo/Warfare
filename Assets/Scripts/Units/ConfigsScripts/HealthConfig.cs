using System;
using UnityEngine;

[Serializable]
public class HealthConfig
{
    [field: SerializeField] public int MaxHealth { get; private set; }
}
