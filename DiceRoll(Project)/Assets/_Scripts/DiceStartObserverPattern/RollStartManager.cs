using UnityEngine;
using UISpace;
using Zenject;
using ParticleSpace;

namespace DiceSpace.StartObserver
{
    public sealed class RollStartManager : MonoBehaviour
    {
        [Space(20)]
        [Header("Rect Transforms")]
        [SerializeField] private RectTransform diceTransform;
        [SerializeField] private RectTransform auraParticleTransform;
        [SerializeField] private RectTransform pathTransform;

        [Space(20)]
        [Header("Start Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private AuraParticle auraParticle;
        private DiceSideSetter sideSetter;
        private FollowDice followDice;
        private RollStart diceStart;
        private DiceRotate diceRotate;
        private DiceRoll diceRoll;
        private PlayButton playButton;

        [Inject]
        public void Constructor(DiceSideSetter sideSetter, PlayButton playButton)
        {
            this.sideSetter = sideSetter;
            this.playButton = playButton;
        }

        private void Awake()
        {
            followDice = new FollowDice(diceTransform, auraParticleTransform, pathTransform);
            diceStart = new RollStart();
            diceRotate = new DiceRotate(diceTransform);
            diceRoll = new DiceRoll(diceTransform);
        }

        private void OnEnable()
        {
            diceStart.Add(followDice);
            diceStart.Add(uiManager);
            diceStart.Add(playButton);
            diceStart.Add(diceRoll);
            diceStart.Add(diceRotate);
            diceStart.Add(auraParticle);
            diceStart.Add(sideSetter);
        }

        private void OnDestroy() => diceStart.RemoveAll();

        public void NotifyObservers() => diceStart.NotifyObservers();
    }
}