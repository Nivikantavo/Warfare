using UnityEngine;

public class DieState : IState
{
    private Unit _unit;
    private Collider2D _collider;

    public DieState(Unit unit, Collider2D collider)
    {
        _unit = unit;
        _collider = collider;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _unit.UnitView.StartDieing();
        _unit.enabled = false;
        _collider.enabled = false;
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
