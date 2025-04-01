using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit Data Config" , menuName = "Create Unit Data/Unit Data Config")]
public class UnitDataConfig : ScriptableObject
{
    [field: SerializeField] public AttackStateConfig AttackStateConfig { get; private set; }
    [field: SerializeField] public MovmentStateConfig MovmentStateConfig { get; private set; }
    [field: SerializeField] public FinderData FinderData { get; private set; }
    [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
}
