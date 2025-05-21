using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Health Health { get; protected set; }
    public ITarget Target { get; protected set; }
    public UnitView UnitView { get; protected set; }
    public IStateSwitcher StateMachine => Machine;
    public UnitStats Stats => UnitStats;

    protected ITargetFinder TargetFinder;

    protected StateMachine Machine;
    protected Animator Animator;
    protected UnitStats UnitStats;
    protected bool IsInitialized;

    [SerializeField] protected Transform CastRaysPoint;
    [SerializeField] protected Collider2D _collider;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    public virtual void Initialize(UnitStats stats, List<IState> states)
    {
        UnitStats = stats;
        Health = new Health(UnitStats.MaxHealth);
        UnitView = new UnitView(Animator);

        TargetFinder = new EllipseTargetFinder(CastRaysPoint, UnitStats.FinderData);
        Machine = new StateMachine(states);
    }

    public virtual bool CanAttack()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.Position) < UnitStats.StopingDistance && transform.position.y - Target.Position.y < 0.01f)
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
