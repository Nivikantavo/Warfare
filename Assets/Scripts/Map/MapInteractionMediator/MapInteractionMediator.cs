using System;
using UnityEngine;
using Zenject;

public class MapInteractionMediator : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private MainMenuHUD _mainMenuHUD;

    private LevelDataLoader _levelDataLoader;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoaded)
    {
        _levelDataLoader = new LevelDataLoader();
    }

    private void OnEnable()
    {
        _map.LevelClicked += OnLevelClicked;
    }

    private void OnDisable()
    {
        _map.LevelClicked -= OnLevelClicked;
    }

    private void OnLevelClicked(int level)
    {
        LevelConfig levelData = _levelDataLoader.GetLevelData(level);
        _mainMenuHUD.ShowSelectedLevel(levelData);
    }
}
