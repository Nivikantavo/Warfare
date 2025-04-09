public class SceneLoadMediator
{
    private ISimpleSceneLoader _simpleSceneLoader;
    private ILevelSceneLoader _levelSceneLoader;

    public SceneLoadMediator(ISimpleSceneLoader simpleSceneLoader, ILevelSceneLoader levelSceneLoader)
    {
        _simpleSceneLoader = simpleSceneLoader;
        _levelSceneLoader = levelSceneLoader;
    }

    public void GoToGameplayLevel(LevelData levelLoadingData)
        => _levelSceneLoader.LoadScene(levelLoadingData);

    public void GoToMenu()
        => _simpleSceneLoader.LoadScene(SceneID.MenuScene);

    public void GoToStartScene()
        => _simpleSceneLoader.LoadScene(SceneID.StartScene);
}
