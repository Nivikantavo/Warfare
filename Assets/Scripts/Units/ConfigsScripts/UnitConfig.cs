using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Scriptable Objects/UnitConfig")]
public class UnitConfig : ScriptableObject
{
    [field: SerializeField] public UnitDataConfig UnitData {  get; private set; }
    [field: SerializeField] public Unit Prefab { get; private set; }
}
