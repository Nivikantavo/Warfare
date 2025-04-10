using System;
using UnityEngine;
using Zenject;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private LevelInfoPanel _levelInfoPanel;

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
    }

    private void OnDisable()
    {
        _levelInfoPanel.LevelStartClicked -= OnStartLevelClicked;
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


}
