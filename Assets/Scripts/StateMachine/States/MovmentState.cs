using UnityEngine;

public class MovmentState : IState, ICanDieState
{
    private readonly Unit _unit;
    private readonly MovmentStateData _config;

    private float _speed;
    private float _stopingDistance;
    private Vector2 _startDirection;

    public MovmentState(Unit unit)
    {
        _unit = unit;
        _config = _unit.Config.MovmentStateConfig;

        _speed = _config.Speed;
        _stopingDistance = _config.StopingDistance;
        _startDirection = _config.StartDirection;
    }

    public void Enter()
    {
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

        _unit.transform.Translate(direction.normalized * _speed * Time.fixedDeltaTime);
    }
}
