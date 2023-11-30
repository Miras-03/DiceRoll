using DG.Tweening;
using DiceSpace;
using DiceSpace.CompleteObserver;
using ParticleSpace;
using System.Threading.Tasks;
using UISpace;
using UnityEngine;
using Zenject;

namespace AttributeSpace
{
    public sealed class AttributeUseManager : MonoBehaviour, IRollCompleteObserver
    {
        [Space(20)]
        [SerializeField] private RectTransform diceTransform;

        [Space(20)]
        [Header("AttributeObservers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private SparkParticle sparkParticle;

        private PlayButton playButton;
        private AttributeUse attributeUse;
        private DiceScale diceScale;
        private DiceEdge diceEdge;
        private DiceSideSetter sideSetter;

        [Inject]
        public void Constructor(DiceSideSetter sideSetter, DiceEdge diceEdge, PlayButton playButton)
        {
            this.sideSetter = sideSetter;
            this.diceEdge = diceEdge;
            this.playButton = playButton;

            attributeUse = new AttributeUse();
            diceScale = new DiceScale(diceTransform);
        }

        private void OnEnable()
        {
            attributeUse.AddObserver(0, diceScale);
            attributeUse.AddObserver(1, diceEdge);
            attributeUse.AddObserver(2, sideSetter);
            attributeUse.AddObserver(3, sparkParticle);
            attributeUse.AddObserver(4, uiManager);
            attributeUse.AddObserver(5, playButton);
        }

        private void OnDisable() => attributeUse.RemoveAllObservers();

        public async void OnDiceRollCompleted()
        {
            await Task.Delay(1000);
                attributeUse.NotifyObservers();
        }
    }
}