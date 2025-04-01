using UnityEngine;

public class StartIdleState : IdleState
{
    public StartIdleState(Unit unit) : base(unit) {}

    public override void Update()
    {
        base.Update();

        if (Unit.Target != null)
        {
            Unit.StateMachine.SwitchState<MovmentState>();
        }
    }
}
