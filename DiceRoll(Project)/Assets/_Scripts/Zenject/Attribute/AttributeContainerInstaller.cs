using AttributeSpace;
using Zenject;

public sealed class AttributeContainerInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.BindInterfacesAndSelfTo<AttributeContainer>().AsSingle();
}