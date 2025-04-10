using UnityEngine;

public class DieState : IState
{
    private Unit _unit;

    public DieState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _unit.Die();
        _unit.UnitView.StartDieing();
        _unit.enabled = false;
        
    }

    public void Exit()
    {
        _unit.UnitView.StopDieing();
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        
    }
}
