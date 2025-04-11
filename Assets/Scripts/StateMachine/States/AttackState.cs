using UnityEngine;

public class AttackState : IState, ICanDieState
{
    private readonly Unit _unit;

    private AttackStateData _config;

    private float _damage;
    private float _timeBetweenAttack;
    private float _lastAttackTime;

    public AttackState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter()
    {
        GetData();
        _unit.Health.ZeroHPValue += OnHealthValueIsZero;
        _unit.UnitView.StartIdle();
    }

    public void Exit()
    {
        _lastAttackTime = _timeBetweenAttack / 2;
        _unit.Health.ZeroHPValue -= OnHealthValueIsZero;
        _unit.UnitView.StopIdle();
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        if (_unit.CanAttack())
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
            _unit.StateMachine.SwitchState<DelayIdleState>();
        }

    }

    private void GetData()
    {
        _config = _unit.Config.AttackStateConfig;
        _damage = _config.Damage;
        _timeBetweenAttack = _config.TimeBetweenAttack;
        _lastAttackTime = _timeBetweenAttack / 2;
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
