using Zenject;

public class RewardFactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RewardsFactory>().AsSingle();
    }
}
