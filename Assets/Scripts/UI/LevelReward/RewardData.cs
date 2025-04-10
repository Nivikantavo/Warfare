using System;
using UnityEngine;

[Serializable]
public class RewardData
{
    [field: SerializeField] public RewardType ResourceType { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}
