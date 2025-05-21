using UnityEngine;

public class AttackState : IState, ICanDieState
{
    private readonly Unit _unit;

    private UnitStats _unitStates;

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
        _lastAttackTime = _unitStates.AttackCooldown / _unitStates.AttackSpeed;
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
            if (_lastAttackTime > _unitStates.AttackCooldown / _unitStates.AttackSpeed)
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
        _unitStates = _unit.Stats;
        _lastAttackTime = _unitStates.AttackCooldown / _unitStates.AttackSpeed;
    }

    private void Attack(ITarget target)
    {
        target.Health.TakeDamage(_unitStates.Damage);
        _unit.UnitView.StartMeleAttack();
    }

    public void OnHealthValueIsZero()
    {
        _unit.StateMachine.SwitchState<DieState>();
    }
}
