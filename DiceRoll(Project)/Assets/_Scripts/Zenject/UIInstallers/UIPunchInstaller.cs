using Zenject;

public class UIPunchInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<UIPunch>().AsSingle();
}