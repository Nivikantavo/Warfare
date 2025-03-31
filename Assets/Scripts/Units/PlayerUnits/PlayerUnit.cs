using UnityEngine;

public class PlayerUnit : Unit, IEnemyTarget
{
    public Vector3 Position => transform.position;
    public GameObject GameObject => gameObject;

    private void FixedUpdate()
    {
        Target = _targetFinder.GetNearestTarget<IPlayerTarget>();
        _machine.Update();
    }
}
