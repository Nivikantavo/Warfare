using System;
using System.IO;
using UnityEngine;
using Zenject;

public class UnitsFactory
{
    private const string SmallConfig = "Zombie_1";
    private const string MediumConfig = "Zombie_1 1";
    private const string Solder_1 = "Solder_1";

    private UnitConfig _small, _medium, _solder;

    protected IInstantiator Container;

    public UnitsFactory(IInstantiator container)
    {
        Container = container;
        Load();
    }

    public Unit Get(EnemyUnitType unitType, Vector3 position)
    {
        UnitConfig config = GetConfigBy(unitType);
        Unit instance = Container.InstantiatePrefabForComponent<Unit>(config.Prefab, position, Quaternion.identity, null);

        instance.Initialize(config.UnitData);
        return instance;
    }

    public Unit Get(PlayerUnitType unitType, Vector3 position)
    {
        UnitConfig config = GetConfigBy(unitType);
        Unit instance = Container.InstantiatePrefabForComponent<Unit>(config.Prefab, position, Quaternion.identity, null);

        instance.Initialize(config.UnitData);
        return instance;
    }

    protected UnitConfig GetConfigBy(EnemyUnitType unitType)
    {
        switch (unitType)
        {
            case EnemyUnitType.Zombie:
                return _small;
            case EnemyUnitType.FastZombie:
                return _medium;

            default:
                throw new ArgumentException(nameof(unitType));
        }
    }

    protected UnitConfig GetConfigBy(PlayerUnitType unitType)
    {
        switch (unitType)
        {
            case PlayerUnitType.Solder_1:
                return _solder;

            default:
                throw new ArgumentException(nameof(unitType));
        }
    }

    protected virtual void Load()
    {
        _small = Resources.Load<UnitConfig>(Path.Combine(SmallConfig));
        _medium = Resources.Load<UnitConfig>(Path.Combine(MediumConfig));
        _solder = Resources.Load<UnitConfig>(Path.Combine(Solder_1));
    }
}
