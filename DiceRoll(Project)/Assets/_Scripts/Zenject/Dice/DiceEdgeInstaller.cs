using DiceSpace;
using Zenject;

public sealed class DiceEdgeInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<DiceEdge>().AsSingle();
}