using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelRewardView : MonoBehaviour
{
    [SerializeField] private Image _rewardView;
    [SerializeField] private TextMeshProUGUI _rewardAmount;

    public void Initialize(RewardViewConfig levelRewardConfig, int rewardAmount)
    {
        _rewardView.sprite = levelRewardConfig.RewardView;
        _rewardAmount.color = levelRewardConfig.RewardColor;
        _rewardAmount.text = rewardAmount.ToString();
    }
}
