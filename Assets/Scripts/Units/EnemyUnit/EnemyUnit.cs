using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit, IPlayerTarget
{
    public Vector3 Position => transform.position;
    public GameObject GameObject => gameObject;

    private void FixedUpdate()
    {
        Target = _targetFinder.GetNearestTarget<IEnemyTarget>();
        _machine.Update();
    }

    public override void Initialize(UnitDataConfig config)
    {
        _unitConfig = config;
        Health = new Health(_unitConfig.HealthConfig.MaxHealth);
        _unitView = new UnitView(_animator);

        List<IState> states = new List<IState>()
        {
            new StartIdleState(this),
            new DelayIdleState(this),
            new MovmentState(this),
            new AttackState(this),
            new DieState(this, _collider)
        };
        _targetFinder = new ForvardTargetFinder(CastRaysPoint, _unitConfig.FinderData);
        _machine = new StateMachine(states);

    }
}
