using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Health Health { get; private set; }
    public ITarget Target { get; protected set; }
    public IStateSwitcher StateMachine => _machine;
    public UnitConfig Config => _unitConfig;

    protected ITargetFinder _targetFinder;

    protected StateMachine _machine;

    //прокинуть зенжектом
    [SerializeField] private UnitConfig _unitConfig;

    private void Awake()
    {
        Initialize(_unitConfig);
    }

    public void Initialize(UnitConfig config)
    {
        _unitConfig = config;
        Health = new Health(_unitConfig.HealthConfig.MaxHealth);

        List<IState> states = new List<IState>()
        {
            new MovmentState(this),
            new IdleState(),
            new AttackState(this),
            new DieState()
        };
        _targetFinder = new EllipseTargetFinder(transform, _unitConfig.FinderData);
        _machine = new StateMachine(states);
    }

    
}
