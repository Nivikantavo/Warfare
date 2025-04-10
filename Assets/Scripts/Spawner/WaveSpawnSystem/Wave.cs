using System;
using UnityEngine;

[Serializable]
public class Wave
{
    [field: SerializeField] public EnemyUnitType SpawnedUnit { get; private set; }
    [field: SerializeField] public int UnitsCount { get; private set; }
    [field: SerializeField] public float DelayBetweenSpawn { get; private set; }
    [field: SerializeField] public float DelayAfterWave { get; private set; }
}
