using System;

[Serializable]
public class LevelRewardViewData
{
    public RewardViewConfig LevelReward { get; private set; }

    public LevelRewardViewData(RewardViewConfig levelReward)
    {
        LevelReward = levelReward;
    }
}
