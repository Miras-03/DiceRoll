using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class ImageInstaller : MonoInstaller
{
    [SerializeField] private Image[] images;
    public override void InstallBindings() => Container.BindInstance(images);
}