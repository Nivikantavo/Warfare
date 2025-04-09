using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [field: SerializeField] public int LevelIndex { get; private set; }
    //Волны противников
    [field: SerializeField] public List<RewardData> RewardData { get; private set; } //Награда за уровень
    //пройден ли
    //количество звезд

}
