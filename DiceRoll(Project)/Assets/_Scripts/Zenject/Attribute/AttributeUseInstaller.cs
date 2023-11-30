using AttributeSpace;
using Zenject;

public class AttributeUseInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<AttributeUse>().AsSingle();
}