using System.IO;
using System;
using UnityEngine;

public class RewardsFactory
{
    private const string GoldConfig = "GoldConfig";
    private const string ExpConfig = "ExpConfig";
    private const string UnitExpCinfig = "UnitExpCinfig";
    private const string FuelConfig = "FuelConfig";

    private RewardViewConfig _gold, _exp, _unitExp, _fuel;

    public RewardsFactory()
    {
        Load();
    }

    public LevelRewardViewData Get(ResourceType resourceType)
    {
        RewardViewConfig config = GetConfigBy(resourceType);
        LevelRewardViewData data = new LevelRewardViewData(config);
        return data;
    }

    private RewardViewConfig GetConfigBy(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Gold:
                return _gold;
            case ResourceType.Experience:
                return _exp;
            case ResourceType.UnitExperience:
                return _unitExp;
            case ResourceType.Fuel:
                return _fuel;
            default:
                throw new ArgumentException(nameof(resourceType));
        }
    }

    private void Load()
    {
        _gold = Resources.Load<RewardViewConfig>(Path.Combine(GoldConfig));
        _exp = Resources.Load<RewardViewConfig>(Path.Combine(ExpConfig));
        _unitExp = Resources.Load<RewardViewConfig>(Path.Combine(UnitExpCinfig));
        _fuel = Resources.Load<RewardViewConfig>(Path.Combine(FuelConfig));
    }
}
