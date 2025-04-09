using System;
using UnityEngine;

[Serializable]
public class RewardData
{
    [field: SerializeField] public ResourceType ResourceType { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}
