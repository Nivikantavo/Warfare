using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit, IEnemyTarget
{
    public Vector3 Position => transform.position;
    public GameObject GameObject => gameObject;

    private void FixedUpdate()
    {
        if (IsInitialized == false)
            return;

        Target = TargetFinder.GetNearestTarget<IPlayerTarget>();
        Machine.Update();
    }

    public override void Initialize(UnitDataConfig config, List<IState> states)
    {
        UnitConfig = config;
        Health = new Health(UnitConfig.HealthConfig.MaxHealth);
        UnitView = new UnitView(Animator);

        TargetFinder = new EllipseTargetFinder(CastRaysPoint, UnitConfig.FinderData);
        Machine = new StateMachine(states);

        IsInitialized = true;
    }
}
