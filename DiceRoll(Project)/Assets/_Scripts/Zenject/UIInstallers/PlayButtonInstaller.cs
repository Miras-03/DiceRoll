using Zenject;

public sealed class PlayButtonInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<PlayButton>().AsSingle();
}