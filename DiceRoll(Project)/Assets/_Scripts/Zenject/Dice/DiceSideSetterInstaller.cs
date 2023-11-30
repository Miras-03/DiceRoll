using DiceSpace;
using Zenject;

public class DiceSideSetterInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DiceSideSetter>().AsSingle();
}