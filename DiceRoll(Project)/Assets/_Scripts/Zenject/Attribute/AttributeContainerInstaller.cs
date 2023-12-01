using AttributeSpace;
using Zenject;

public sealed class AttributeContainerInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<AttributeContainer>().AsSingle();
}