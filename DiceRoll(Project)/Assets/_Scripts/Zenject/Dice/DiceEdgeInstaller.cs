using DiceSpace;
using Zenject;

public class DiceEdgeInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DiceEdge>().AsSingle();
}