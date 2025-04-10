using Zenject;

public class UnitsFactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UnitsFactory>().AsSingle();
    }
}
