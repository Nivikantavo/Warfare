using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuHUD : MonoBehaviour
{
    [Header("Level Info Panel")]
    [SerializeField] private LevelInfoPanel _levelInfoPanel;

    [Space, Header("Team Settings Panel")]
    [SerializeField] private TeamSettingsPanel _teamSettingsPanel;
    [SerializeField] private Button _teamSettingsShowButton;
    [SerializeField] private Button _teamSettingsHideButton;

    private SceneLoadMediator _sceneLoader;

    private LevelConfig _selectedLevelData;

    public void ShowSelectedLevel(LevelConfig levelData)
    {
        if (levelData == null)
            throw new ArgumentException(nameof(levelData));

        _selectedLevelData = levelData;

        ShowLevelInfo(_selectedLevelData);
    }

    [Inject]
    private void Construct(SceneLoadMediator sceneLoaded)
    {
        _sceneLoader = sceneLoaded;
    }

    private void OnEnable()
    {
        _levelInfoPanel.LevelStartClicked += OnStartLevelClicked;
        _teamSettingsShowButton.onClick.AddListener(ShowTeamSettingsPanel);
        _teamSettingsHideButton.onClick.AddListener(HideTeamSettingsPanel);
    }

    private void OnDisable()
    {
        _levelInfoPanel.LevelStartClicked -= OnStartLevelClicked;
        _teamSettingsShowButton.onClick.RemoveListener(ShowTeamSettingsPanel);
        _teamSettingsHideButton.onClick.RemoveListener(HideTeamSettingsPanel);
    }

    private void ShowLevelInfo(LevelConfig levelData)
    {
        _levelInfoPanel.Initialize(levelData);
        _levelInfoPanel.gameObject.SetActive(true);
    }

    private void OnStartLevelClicked()
    {
        _sceneLoader.GoToGameplayLevel(_selectedLevelData);
    }

    private void ShowTeamSettingsPanel()
    {
        _teamSettingsPanel.Show();
    }

    private void HideTeamSettingsPanel()
    {
        _teamSettingsPanel.Hide();
    }


}
