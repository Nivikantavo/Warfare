using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLoader();
    }

    private void BindLoader()
    {
        Container.BindInterfacesTo<SceneLoader>().AsSingle();
        Container.Bind<SceneLoadMediator>().AsSingle();
    }
}
