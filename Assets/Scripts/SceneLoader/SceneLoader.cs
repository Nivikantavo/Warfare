using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : ISimpleSceneLoader, ILevelSceneLoader
{
    private readonly ZenjectSceneLoader _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoader zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;
    }

    public void LoadScene(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayScene)
            throw new System.ArgumentException($"Cand load {SceneID.GameplayScene} with this method");

        Load(null, (int)sceneID);
    }

    public void LoadScene(LevelData lveleLoadingData)
    {
        Load(container =>
        {
            container.BindInstance(lveleLoadingData).AsSingle();
        }
        , (int)SceneID.GameplayScene);
    }

    private void Load(Action<DiContainer> action, int sceneID)
    {
        _zenjectSceneLoader.LoadScene(sceneID, LoadSceneMode.Single, action);
    }
}
