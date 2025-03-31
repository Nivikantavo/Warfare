using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit Config" , menuName = "Create Unit/Unit Config")]
public class UnitConfig : ScriptableObject
{
    [field: SerializeField] public AttackStateConfig AttackStateConfig;
    [field: SerializeField] public MovmentStateConfig MovmentStateConfig;
    [field: SerializeField] public FinderData FinderData;
    [field: SerializeField] public HealthConfig HealthConfig;
}
