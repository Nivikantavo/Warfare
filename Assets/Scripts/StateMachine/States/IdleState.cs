using UnityEngine;

public class IdleState : IState, ICanDieState
{
    Unit _unit;

    public IdleState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log(GetType());

        _unit.Health.ZeroHPValue += OnHealthValueIsZero;
        _unit.UnitView.StartIdle();
    }

    public void Exit()
    {
        _unit.Health.ZeroHPValue -= OnHealthValueIsZero;
        _unit.UnitView.StopIdle();
    }

    public void HandleInput()
    {
        
    }

    public void OnHealthValueIsZero()
    {
        _unit.StateMachine.SwitchState<DieState>();
    }

    public void Update()
    {
        
    }
}
