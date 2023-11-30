using AttributeSpace;
using Zenject;

public sealed class AttributeUseInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<AttributeUse>().AsSingle();
}