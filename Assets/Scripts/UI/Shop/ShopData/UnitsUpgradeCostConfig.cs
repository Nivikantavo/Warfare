using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsUpgradeCostConfig", menuName = "Shop/UnitsUpgradeCostConfig")]
public class UnitsUpgradeCostConfig : ScriptableObject
{
    [field: SerializeField] public List<int> UpgradesCostByLevel;  
}
