using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoPanel : MonoBehaviour
{
    [SerializeField] private Button _startLevelButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private TextMeshProUGUI _levelIndex;
    [SerializeField] private TextMeshProUGUI _levelComplexity;

    [SerializeField] private LevelRewardPanel _rewardPanel;
}
