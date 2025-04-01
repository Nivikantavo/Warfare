using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Health Health { get; protected set; }
    public ITarget Target { get; protected set; }
    public IStateSwitcher StateMachine => _machine;
    public UnitDataConfig Config => _unitConfig;
    public UnitView UnitView => _unitView;

    protected ITargetFinder _targetFinder;

    protected StateMachine _machine;
    protected UnitView _unitView;
    protected Animator _animator;

    //прокинуть зенжектом
    [SerializeField] protected UnitDataConfig _unitConfig;
    [SerializeField] protected Transform CastRaysPoint;
    [SerializeField] protected Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public virtual void Initialize(UnitDataConfig config)
    {
        _unitConfig = config;
        Health = new Health(_unitConfig.HealthConfig.MaxHealth);
        _unitView = new UnitView(_animator);

        List<IState> states = new List<IState>()
        {
            new MovmentState(this),
            new DelayIdleState(this),
            new AttackState(this),
            new DieState(this, _collider)
        };
        _targetFinder = new EllipseTargetFinder(CastRaysPoint, _unitConfig.FinderData);
        _machine = new StateMachine(states);
    }

    public virtual bool CanAttack()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.Position) < _unitConfig.MovmentStateConfig.StopingDistance && transform.position.y - Target.Position.y < 0.1f)
            {
                return true;
            }
        }
        return false;
    }

    
}
