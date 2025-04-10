using System.IO;
using System;
using UnityEngine;
using Zenject;

public class RewardsFactory
{
    private const string RewardConfigsPath = "RewardConfigs";
    private const string GoldConfig = "GoldConfig";
    private const string ExpConfig = "ExpConfig";
    private const string UnitExpCinfig = "UnitExpCinfig";

    private RewardViewConfig _gold, _exp, _unitExp;
    private IInstantiator Container;

    public RewardsFactory(IInstantiator container)
    {
        Container = container;
        Load();
    }

    public LevelRewardView Get(RewardType resourceType, int rewardAmount)
    {
        RewardViewConfig config = GetConfigBy(resourceType);
        LevelRewardView instance = Container.InstantiatePrefabForComponent<LevelRewardView>(config.Prefab);
        instance.Initialize(config, rewardAmount);
        return instance;
    }

    private RewardViewConfig GetConfigBy(RewardType resourceType)
    {
        switch (resourceType)
        {
            case RewardType.Gold:
                return _gold;
            case RewardType.Experience:
                return _exp;
            case RewardType.UnitExperience:
                return _unitExp;
            default:
                throw new ArgumentException(nameof(resourceType));
        }
    }

    private void Load()
    {
        _gold = Resources.Load<RewardViewConfig>(Path.Combine(RewardConfigsPath, GoldConfig));
        _exp = Resources.Load<RewardViewConfig>(Path.Combine(RewardConfigsPath, ExpConfig));
        _unitExp = Resources.Load<RewardViewConfig>(Path.Combine(RewardConfigsPath, UnitExpCinfig));
    }
}
