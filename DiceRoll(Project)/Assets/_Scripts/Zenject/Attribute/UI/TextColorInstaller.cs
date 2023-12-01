using Zenject;

public class TextColorInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<TextColor>().AsSingle();
}