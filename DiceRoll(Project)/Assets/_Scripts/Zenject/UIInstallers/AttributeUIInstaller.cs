using AttributeSpace;
using UnityEngine;
using Zenject;

public class AttributeUIInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<AttributeUI>().FromComponentInHierarchy().AsSingle();
}