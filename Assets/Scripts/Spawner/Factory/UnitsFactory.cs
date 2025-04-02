using System;
using System.IO;
using UnityEngine;
using Zenject;

public class UnitsFactory
{
    private const string SmallConfig = "Zombie_1";
    private const string MediumConfig = "Zombie_1 1";
    private const string Solder_1 = "Solder_1";
    private const string Sitiman_1 = "Sitiman_1";

    private UnitConfig _small, _medium, _solder_1, _sityman_1;

    private IInstantiator Container;

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

    private UnitConfig GetConfigBy(EnemyUnitType unitType)
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

    private UnitConfig GetConfigBy(PlayerUnitType unitType)
    {
        switch (unitType)
        {
            case PlayerUnitType.Solder_1:
                return _solder_1;
            case PlayerUnitType.Sityman_1:
                return _sityman_1;

            default:
                throw new ArgumentException(nameof(unitType));
        }
    }

    private void Load()
    {
        _small = Resources.Load<UnitConfig>(Path.Combine(SmallConfig));
        _medium = Resources.Load<UnitConfig>(Path.Combine(MediumConfig));
        _solder_1 = Resources.Load<UnitConfig>(Path.Combine(Solder_1));
        _sityman_1 = Resources.Load<UnitConfig>(Path.Combine(Sitiman_1));
    }
}
