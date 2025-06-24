using UnityEngine;

[CreateAssetMenu(fileName = "DefaultData", menuName = "PlayerData/DefaultData")]
public class DefaultData : ScriptableObject
{
    [field: SerializeField] public int StartGold {  get; private set; }
    [field: SerializeField] public int StartUnitsExpAmount { get; private set; }
    [field: SerializeField] public int StartFuelAmount { get; private set; }
    [field: SerializeField] public int MaxFuelAmount { get; private set; }
    [field: SerializeField] public string StartPickedUnit { get; private set; }
}
