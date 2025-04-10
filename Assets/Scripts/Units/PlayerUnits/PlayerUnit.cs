using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit, IEnemyTarget
{
    public Vector3 Position => transform.position;
    public GameObject GameObject => gameObject;

    private void FixedUpdate()
    {
        if (_isInitialized == false)
            return;

        Target = _targetFinder.GetNearestTarget<IPlayerTarget>();
        _machine.Update();
    }

    public override void Initialize(UnitDataConfig config, List<IState> states)
    {
        _unitConfig = config;
        Health = new Health(_unitConfig.HealthConfig.MaxHealth);
        _unitView = new UnitView(_animator);

        _targetFinder = new EllipseTargetFinder(CastRaysPoint, _unitConfig.FinderData);
        _machine = new StateMachine(states);

        _isInitialized = true;
    }
}
