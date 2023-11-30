using AttributeSpace;
using Zenject;

public class AttributeContainerInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<AttributeContainer>().AsSingle();
}