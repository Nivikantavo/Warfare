using UnityEngine;

public class MovmentState : IState, ICanDieState
{
    private readonly Unit _unit;
    private UnitStats _unitStats;

    private Vector2 _startDirection;

    public MovmentState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        GetData();
        _unit.Health.ZeroHPValue += OnHealthValueIsZero;
        _unit.UnitView.StartWalkingt();
    }

    public void Exit()
    {
        _unit.Health.ZeroHPValue -= OnHealthValueIsZero;
        _unit.UnitView.StopWalking();
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
        Move();

        if (_unit.Target != null)
        {
            if (_unit.CanAttack())
            {
                _unit.StateMachine.SwitchState<AttackState>();
            }
        }
    }

    private void GetData()
    {
        _unitStats = _unit.Stats;

        _startDirection = _unitStats.StartDirection;
    }

    private void Move()
    {
        Vector2 direction;

        if (_unit.Target != null)
        {
            direction = _unit.Target.Position - _unit.transform.position;
            direction = new Vector2(direction.x, direction.y);
        }
        else
        {
            direction = _startDirection;
        }

        _unit.transform.Translate(direction.normalized * _unitStats.Speed * Time.fixedDeltaTime);
    }
}
