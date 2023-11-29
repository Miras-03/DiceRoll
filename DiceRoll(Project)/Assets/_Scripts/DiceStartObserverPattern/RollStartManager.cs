using UnityEngine;
using UISpace;
using Zenject;
using ParticleSpace;

namespace DiceSpace.StartObserver
{
    public sealed class RollStartManager : MonoBehaviour
    {
        [SerializeField] private RectTransform diceTransform;
        [SerializeField] private RectTransform pathTransform;

        [Space(20)]
        [Header("Start Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private AuraParticle auraParticle;
        [SerializeField] private FollowDice followDice;
        private RollStart diceStart;
        private DiceSideSetter diceSideSetter;
        private DiceRotate diceRotate;
        private DiceRoll diceRoll;
        private PlayButton playButton;

        [Inject]
        public void Constructor(PlayButton playButton) => this.playButton = playButton;

        private void Awake()
        {
            diceStart = new RollStart();
            diceSideSetter = new DiceSideSetter(diceTransform);
            diceRotate = new DiceRotate(diceTransform);
            diceRoll = new DiceRoll(diceTransform, pathTransform);
        }

        private void OnEnable()
        {
            diceStart.Add(followDice);
            diceStart.Add(uiManager);
            diceStart.Add(playButton);
            diceStart.Add(diceRoll);
            diceStart.Add(diceRotate);
            diceStart.Add(diceSideSetter);
            diceStart.Add(auraParticle);
        }

        private void OnDestroy() => diceStart.RemoveAll();

        public void NotifyObservers() => diceStart.NotifyObservers();
    }
}