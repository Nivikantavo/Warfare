using UnityEngine;

public class EnemyUnit : MonoBehaviour, IPlayerTarget
{
    public Vector3 Position => transform.position;

    public GameObject GameObject => gameObject;
}
