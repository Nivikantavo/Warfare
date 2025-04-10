using System.Collections.Generic;
using System.Linq;
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
    protected UnitDataConfig _unitConfig;
    protected bool _isInitialized;

    [SerializeField] protected Transform CastRaysPoint;
    [SerializeField] protected Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public virtual void Initialize(UnitDataConfig config, List<IState> states)
    {
        _unitConfig = config;
        Health = new Health(_unitConfig.HealthConfig.MaxHealth);
        _unitView = new UnitView(_animator);

        _targetFinder = new EllipseTargetFinder(CastRaysPoint, _unitConfig.FinderData);
        _machine = new StateMachine(states);
    }

    public virtual bool CanAttack()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.Position) < _unitConfig.MovmentStateConfig.StopingDistance && transform.position.y - Target.Position.y < 0.01f)
            {
                return true;
            }
        }
        return false;
    }

    public virtual void Die()
    {
        _collider.enabled = false;
    }
}
