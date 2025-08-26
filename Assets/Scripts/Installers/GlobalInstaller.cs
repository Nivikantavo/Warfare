using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindScensLoader();
        BindSaveLoadService();
    }

    private void BindScensLoader()
    {
        Container.BindInterfacesTo<SceneLoader>().AsSingle();
        Container.Bind<SceneLoadMediator>().AsSingle();
    }

    private void BindSaveLoadService()
    {
        Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
    }
}
