using UnityEngine;

[CreateAssetMenu(fileName = "Player Base Data", menuName = "Create Base Data/Player Base Data")]
public class PlayerBaseData : ScriptableObject
{
    [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
}
