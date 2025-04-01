using UnityEngine;

public class AttackState : IState, ICanDieState
{
    private readonly Unit _unit;

    private readonly AttackStateConfig _config;

    private float _damage;
    private float _timeBetweenAttack;
    private float _lastAttackTime = 0;

    public AttackState(Unit unit)
    {
        _unit = unit;
        _config = unit.Config.AttackStateConfig;
        _damage = _config.Damage;
        _timeBetweenAttack = _config.TimeBetweenAttack;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _unit.Health.ZeroHPValue += OnHealthValueIsZero;
        _unit.UnitView.StartIdle();
    }

    public void Exit()
    {
        _lastAttackTime = 0;
        _unit.Health.ZeroHPValue -= OnHealthValueIsZero;
        _unit.UnitView.StopIdle();
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        if (_unit.Target != null)
        {
            _lastAttackTime += Time.deltaTime;
            if (_lastAttackTime > _timeBetweenAttack)
            {
                Attack(_unit.Target);
                _lastAttackTime = 0;
            }
        }
        else
        {
            _unit.StateMachine.SwitchState<MovmentState>();
        }

    }

    private void Attack(ITarget target)
    {
        target.Health.TakeDamage(_damage);
        _unit.UnitView.StartMeleAttack();
    }

    public void OnHealthValueIsZero()
    {
        _unit.StateMachine.SwitchState<DieState>();
    }
}
