using UnityEngine;

public class MovmentState : IState
{
    private readonly Unit _unit;
    private readonly MovmentStateConfig _config;

    //Взять из конфига
    private float _speed = 1f;
    private float _stopingDistance = 1f;
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
        Debug.Log(GetType());
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        Move();

        if (_unit.Target != null)
        {
            if (Vector3.Distance(_unit.transform.position, _unit.Target.Position) < _stopingDistance)
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
        }
        else
        {
            direction = _startDirection;
        }

        _unit.transform.Translate(direction.normalized * _speed * Time.fixedDeltaTime);
    }
}
