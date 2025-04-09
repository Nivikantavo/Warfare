public abstract class IdleState : IState, ICanDieState
{
    protected Unit Unit;

    public IdleState(Unit unit)
    {
        Unit = unit;
    }

    public virtual void Enter()
    {
        Unit.Health.ZeroHPValue += OnHealthValueIsZero;
        Unit.UnitView.StartIdle();
    }

    public virtual void Exit()
    {
        Unit.Health.ZeroHPValue -= OnHealthValueIsZero;
        Unit.UnitView.StopIdle();
    }

    public virtual void HandleInput()
    {
        
    }

    public void OnHealthValueIsZero()
    {
        Unit.StateMachine.SwitchState<DieState>();
    }

    public virtual void Update()
    {
        
    }
}
