using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelRewardPanel : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ScrollRect _rewardsRect;

    private RewardsFactory _rewardFactory;

    public void Initialize(List<RewardData> rewardList)
    {
        foreach (RewardData reward in rewardList)
        {
            var view = _rewardFactory.Get(reward.ResourceType, reward.Amount);
            view.gameObject.transform.SetParent(_container, false);
        }
    }

    [Inject]
    private void Construct(RewardsFactory rewardFactory)
    {
        _rewardFactory = rewardFactory;
    }

    private void OnEnable()
    {
        _rewardsRect.horizontalNormalizedPosition = 0;
    }

    private void OnDisable()
    {
        foreach (Transform child in _container.transform)
        {
            Destroy(child.gameObject);
            //заменить на работу с пуллом
        }
    }
}
