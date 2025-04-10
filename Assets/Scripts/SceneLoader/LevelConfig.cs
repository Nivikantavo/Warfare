using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public int LevelIndex { get; private set; }
    [field: SerializeField] public List<Wave> Waves { get; private set; }
    [field: SerializeField] public List<Wave> PreSpawnedWave { get; private set; }
    [field: SerializeField] public List<RewardData> RewardData { get; private set; }

    public bool IsComplited { get; private set; }
    public int CurrentStarsCount { get; private set; }

}
