using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class UnitsFactory
{
    private const string EnemyUnitsPath = "UnitsConfigs/EnemyConfigs";
    private const string PlayerUnitsPath = "UnitsConfigs/PlayerUnitsConfigs";

    private const string SmallConfig = "Zombie_1";
    private const string MediumConfig = "Zombie_1 1";
    private const string Solder_1 = "Solder_1";
    private const string Cityman_1 = "Cityman_1";
    private const string Cityman_2 = "Cityman_2";
    private const string Cityman_3 = "Cityman_3";
    private const string Rider_3 = "Rider_3";

    private UnitDataConfig _small, _medium, _solder_1, _cityman_1, _cityman_2, _cityman_3, _rider_3;

    private IInstantiator _container;
    private StateAssembler _stateAssembler = new StateAssembler();
    public UnitsFactory(IInstantiator container)
    {
        _container = container;
        Load();
    }

    public Unit GetEnemyUnit(EnemyUnitType unitType, Vector3 position, ShopUpgradeData shopUpgradeData, RuntimeContext runtimeContext = null)
    {
        UnitDataConfig config = GetEnemyConfigBy(unitType);
        
        Unit instance = _container.InstantiatePrefabForComponent<Unit>(config.Prefab, position, Quaternion.identity, null);
        List<IState> states = _stateAssembler.AssembleStates(instance, config, runtimeContext);

        UnitStats unitStats = StatModifierApplier.GetModifiedStats(config, shopUpgradeData.Level);

        instance.Initialize(unitStats, states);
        return instance;
    }

    public Unit GetPlayerUnit(PlayerUnitType unitType, Vector3 position, ShopUpgradeData shopUpgradeData, RuntimeContext runtimeContext = null)
    {
        UnitDataConfig config = GetPlayerUnitConfigBy(unitType);

        Unit instance = _container.InstantiatePrefabForComponent<Unit>(config.Prefab, position, Quaternion.identity, null);
        List<IState> states = _stateAssembler.AssembleStates(instance, config, runtimeContext);

        UnitStats unitStats = StatModifierApplier.GetModifiedStats(config, shopUpgradeData.Level);

        instance.Initialize(unitStats, states);
        return instance;
    }

    private UnitDataConfig GetEnemyConfigBy(EnemyUnitType unitType)
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

    private UnitDataConfig GetPlayerUnitConfigBy(PlayerUnitType unitType)
    {
        switch (unitType)
        {
            case PlayerUnitType.Solder_1:
                return _solder_1;
            case PlayerUnitType.Cityman_1:
                return _cityman_1;
            case PlayerUnitType.Cityman_2:
                return _cityman_2;
            case PlayerUnitType.Cityman_3:
                return _cityman_3;
            case PlayerUnitType.Rider_3:
                return _rider_3;

            default:
                throw new ArgumentException(nameof(unitType));
        }
    }

    private void Load()
    {
        _small = Resources.Load<UnitDataConfig>(Path.Combine(EnemyUnitsPath, SmallConfig));
        _medium = Resources.Load<UnitDataConfig>(Path.Combine(EnemyUnitsPath, MediumConfig));

        _solder_1 = Resources.Load<UnitDataConfig>(Path.Combine(PlayerUnitsPath, Solder_1));
        _cityman_1 = Resources.Load<UnitDataConfig>(Path.Combine(PlayerUnitsPath, Cityman_1));
        _cityman_2 = Resources.Load<UnitDataConfig>(Path.Combine(PlayerUnitsPath, Cityman_2));
        _cityman_3 = Resources.Load<UnitDataConfig>(Path.Combine(PlayerUnitsPath, Cityman_3));
        _rider_3 = Resources.Load<UnitDataConfig>(Path.Combine(PlayerUnitsPath, Rider_3));
    }
}
