using Zenject;

public sealed class DifficultyClassInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DifficultyClass>().AsSingle();
}