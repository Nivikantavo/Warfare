using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit Data Config" , menuName = "Create Unit Data/Unit Data Config")]
public class UnitDataConfig : ScriptableObject
{
    [field: SerializeField] public Unit Prefab { get; private set; }
    [field: SerializeField] public AttackStateData AttackStateConfig { get; private set; }
    [field: SerializeField] public MovmentStateData MovmentStateConfig { get; private set; }
    [field: SerializeField] public FinderData FinderData { get; private set; }
    [field: SerializeField] public HealthData HealthConfig { get; private set; }
    [field: SerializeField] public List<StateConfigSO> States { get; private set; }

    public void SetStates(List<StateConfigSO> newStates)
    {
        States = newStates;
    }
}
