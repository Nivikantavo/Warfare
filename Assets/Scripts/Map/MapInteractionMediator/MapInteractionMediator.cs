using System;
using UnityEngine;
using Zenject;

public class MapInteractionMediator : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private MainMenuHUD _mainMenuHUD;

    private SceneLoadMediator _sceneLoader;
    private LevelDataLoader _levelDataLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoaded)
    {
        _sceneLoader = sceneLoaded;
        _levelDataLoader = new LevelDataLoader();
    }

    private void OnEnable()
    {
        _map.LevelSelected += OnLevelSelected;
    }

    private void OnDisable()
    {
        _map.LevelSelected -= OnLevelSelected;
    }

    private void OnLevelSelected(int level)
    {
        LevelData levelData = _levelDataLoader.GetLevelData(level);
        _sceneLoader.GoToGameplayLevel(levelData);
    }
}
