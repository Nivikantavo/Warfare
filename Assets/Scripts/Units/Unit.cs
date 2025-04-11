using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Health Health { get; protected set; }
    public ITarget Target { get; protected set; }
    public UnitView UnitView { get; protected set; }
    public IStateSwitcher StateMachine => Machine;
    public UnitDataConfig Config => UnitConfig;
    

    protected ITargetFinder TargetFinder;

    protected StateMachine Machine;
    protected Animator Animator;
    protected UnitDataConfig UnitConfig;
    protected bool IsInitialized;

    [SerializeField] protected Transform CastRaysPoint;
    [SerializeField] protected Collider2D _collider;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    public virtual void Initialize(UnitDataConfig config, List<IState> states)
    {
        UnitConfig = config;
        Health = new Health(UnitConfig.HealthConfig.MaxHealth);
        UnitView = new UnitView(Animator);

        TargetFinder = new EllipseTargetFinder(CastRaysPoint, UnitConfig.FinderData);
        Machine = new StateMachine(states);
    }

    public virtual bool CanAttack()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.Position) < UnitConfig.MovmentStateConfig.StopingDistance && transform.position.y - Target.Position.y < 0.01f)
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
