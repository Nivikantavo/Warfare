using UnityEngine;

public class Solder : MonoBehaviour, IEnemyTarget
{
    public Health Health { get; private set; }

    public Vector3 Position => transform.position;
}
