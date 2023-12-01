using AttributeSpace;
using Zenject;

public sealed class AttributeIndicatorInstaller : MonoInstaller
{
    public override void InstallBindings() => 
        Container.BindInterfacesAndSelfTo<AttributeIndicator>().AsSingle();
}
