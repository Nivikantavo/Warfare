using System;
using UnityEngine;

[Serializable]
public class SpawningData
{
    [field: SerializeField] public float SpawningCooldown { get; private set; }
    [field: SerializeField] public int SpawningCost { get; private set; }
}
