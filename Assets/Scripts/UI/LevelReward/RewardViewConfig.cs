using UnityEngine;

[CreateAssetMenu(fileName = "RewardViewConfig", menuName = "Scriptable Objects/RewardViewConfig")]
public class RewardViewConfig : ScriptableObject
{
    [field: SerializeField] public LevelRewardView Prefab { get; private set; }
    [field: SerializeField] public Sprite RewardView { get; private set; }
    [field: SerializeField] public Color RewardColor { get; private set; }
    [field: SerializeField] public ResourceType ResourceType { get; private set; }
}
