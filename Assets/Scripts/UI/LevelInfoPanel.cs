using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoPanel : MonoBehaviour
{
    public event Action LevelStartClicked;

    [SerializeField] private Button _startLevelButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _anticlick;

    [SerializeField] private TextMeshProUGUI _levelIndex;
    [SerializeField] private TextMeshProUGUI _levelComplexity;

    [SerializeField] private LevelRewardPanel _rewardPanel;

    public void Initialize(LevelConfig levelData)
    {
        _levelIndex.text = string.Format(_levelIndex.text, levelData.LevelIndex);
        _rewardPanel.Initialize(levelData.RewardData);
    }

    private void OnEnable()
    {
        _startLevelButton.onClick.AddListener(StartLevelClicked);
        _closeButton.onClick.AddListener(HidePanel);
        _anticlick.onClick.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        _startLevelButton.onClick.RemoveListener(StartLevelClicked);
        _closeButton.onClick.RemoveListener(HidePanel);
        _anticlick.onClick.RemoveListener(HidePanel);
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }

    private void StartLevelClicked()
    {
        LevelStartClicked?.Invoke();
    }

}
