using Zenject;

public sealed class PlayButtonInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.BindInterfacesAndSelfTo<PlayButton>().AsSingle();
}