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

    public override void Initialize(UnitStats stats, List<IState> states)
    {
        UnitStats = stats;
        Health = new Health(UnitStats.MaxHealth);
        UnitView = new UnitView(Animator);

        TargetFinder = new EllipseTargetFinder(CastRaysPoint, UnitStats.FinderData);
        Machine = new StateMachine(states);

        IsInitialized = true;
    }
}
