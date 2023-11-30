using DiceSpace;
using Zenject;

public sealed class DiceSideSetterInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DiceSideSetter>().AsSingle();
}