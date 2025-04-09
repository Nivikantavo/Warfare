using System.Collections.Generic;
using UnityEngine;

public class LevelRewardPanel : MonoBehaviour
{
    [SerializeField] private LevelRewardView _rewardViewTemplate;
    [SerializeField] private Transform _container;

    private RewardsFactory _rewardFactory;

    public void Initialize(List<RewardData> rewardList)
    {
        foreach (RewardData reward in rewardList)
        {
            var viewData = _rewardFactory.Get(reward.ResourceType);
            var view = Instantiate(_rewardViewTemplate, _container);
            view.Initialize(viewData, reward.Amount);
        }
    }
}
