using System;
using System.Collections.Generic;
using UnityEngine;

public static class StatModifierApplier
{
    public static UnitStats GetModifiedStats(UnitDataConfig config, int level, List<StatModifier> artefacts = null)
    {
        UnitStats resultStats = SetBaseValue(config);

        ApplyLevelModifiers(ref resultStats, level);

        var actions = GetModifierMap(resultStats);

        foreach (var mod in artefacts)
        {
            if (actions.TryGetValue(mod.TypeOfStat, out var applyAction))
            {
                applyAction(mod);
            }
            else
            {
                Debug.LogWarning($"StatModifierApplier: Unknown stat '{mod.TypeOfStat}'");
            }
        }

        return resultStats;
    }

    private static Dictionary<StatType, Action<StatModifier>> GetModifierMap(UnitStats unitStats)
    {
        return new Dictionary<StatType, Action<StatModifier>>
        {
            [StatType.Health] = mod =>
                unitStats.MaxHealth = mod.ApplyModifier(unitStats.MaxHealth),

            [StatType.Damage] = mod =>
                unitStats.Damage = mod.ApplyModifier(unitStats.Damage),

            [StatType.AttackSpeed] = mod =>
                unitStats.AttackCooldown = mod.ApplyModifier(unitStats.AttackSpeed),

            [StatType.MoveSpeed] = mod =>
                unitStats.Speed = mod.ApplyModifier(unitStats.Speed),

        };
    }

    private static UnitStats SetBaseValue(UnitDataConfig config)
    {
        UnitStats baseStats = new UnitStats();

        baseStats.Damage = config.AttackStateConfig.Damage;
        baseStats.AttackCooldown = config.AttackStateConfig.AttackCooldown;
        baseStats.Speed = config.MovmentStateConfig.Speed;
        baseStats.StopingDistance = config.MovmentStateConfig.StopingDistance;
        baseStats.MaxHealth = config.HealthConfig.MaxHealth;

        return baseStats;
    }

    private static void ApplyLevelModifiers(ref UnitStats unitStats, int level)
    {
        LevelStatModifire damage = new LevelStatModifire(level, StatType.Damage);
        LevelStatModifire attackSpeed = new LevelStatModifire(level, StatType.AttackSpeed);
        LevelStatModifire speed = new LevelStatModifire(level, StatType.MoveSpeed);
        LevelStatModifire maxHealth = new LevelStatModifire(level, StatType.Health);

        unitStats.Damage = damage.ApplyModifier(unitStats.Damage);
        unitStats.AttackSpeed = attackSpeed.ApplyModifier(unitStats.AttackSpeed);
        unitStats.Speed = speed.ApplyModifier(unitStats.Speed);
        unitStats.MaxHealth = maxHealth.ApplyModifier(unitStats.MaxHealth);
    }
}
