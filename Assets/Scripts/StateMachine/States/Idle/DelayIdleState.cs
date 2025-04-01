using Cysharp.Threading.Tasks;
using UnityEngine;

public class DelayIdleState : IdleState
{
    public DelayIdleState(Unit unit) : base(unit) {}

    public override void Enter()
    {
        base.Enter();
        SetNextStateWithDelay();
    }

    private async void SetNextStateWithDelay()
    {
        await UniTask.WaitForSeconds(1);
        Unit.StateMachine.SwitchState<MovmentState>();
    }
}
