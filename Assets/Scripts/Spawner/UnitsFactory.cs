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

    private IInstantiator _container;

    public UnitsFactory(IInstantiator container)
    {
        _container = container;
        Load();
    }

    public Unit Get(UnitsType unitType, Vector3 position)
    {
        UnitConfig config = GetConfigBy(unitType);
        Unit instance = _container.InstantiatePrefabForComponent<Unit>(config.Prefab, position, Quaternion.identity, null);

        instance.Initialize(config.UnitData);
        return instance;
    }

    private UnitConfig GetConfigBy(UnitsType unitType)
    {
        switch (unitType)
        {
            case UnitsType.Zombie:
                return _small;
            case UnitsType.FastZombie:
                return _medium;
            case UnitsType.Solder_1:
                return _solder;

            default:
                throw new ArgumentException(nameof(unitType));
        }
    }

    private void Load()
    {
        _small = Resources.Load<UnitConfig>(Path.Combine(SmallConfig));
        _medium = Resources.Load<UnitConfig>(Path.Combine(MediumConfig));
        _solder = Resources.Load<UnitConfig>(Path.Combine(Solder_1));
        Debug.Log(_small);
        Debug.Log(_medium);
        Debug.Log(_solder);
    }
}
