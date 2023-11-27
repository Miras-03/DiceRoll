using Zenject;

public class DifficultyClassInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DifficultyClass>().AsSingle();
}