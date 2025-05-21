using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit, IPlayerTarget
{
    public Vector3 Position => transform.position;
    public GameObject GameObject => gameObject;

    private void FixedUpdate()
    {
        if(IsInitialized == false)
            return;

        Target = TargetFinder.GetNearestTarget<IEnemyTarget>();
        Machine.Update();
    }

    public override void Initialize(UnitStats stats, List<IState> states)
    {
        UnitStats = stats;
        Health = new Health(UnitStats.MaxHealth);
        UnitView = new UnitView(Animator);


        TargetFinder = new ForvardTargetFinder(CastRaysPoint, UnitStats.FinderData);

        Machine = new StateMachine(states);

        IsInitialized = true;
    }
}
