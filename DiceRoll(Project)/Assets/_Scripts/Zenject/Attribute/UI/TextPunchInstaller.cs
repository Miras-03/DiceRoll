using Zenject;

namespace UISpace
{
    public sealed class TextPunchInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.Bind<TextPunch>().AsSingle();
    }
}