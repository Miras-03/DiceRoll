using Zenject;

public class PlayButtonInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<PlayButton>().AsSingle();
}