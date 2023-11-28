using UnityEngine;
using UISpace;
using Zenject;
using ParticleSpace;

namespace DiceSpace.StartObserver
{
    public sealed class RollStartManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private RectTransform diceTransform;
        [SerializeField] private RectTransform pathsParent;

        [Space(20)]
        [Header("Start Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private FollowDice followDice;
        [SerializeField] private AuraParticle auraParticle;
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
            diceRoll = new DiceRoll(diceTransform, pathsParent);
        }

        private void OnEnable()
        {
            diceStart.Add(uiManager);
            diceStart.Add(playButton);
            diceStart.Add(diceRoll);
            diceStart.Add(diceRotate);
            diceStart.Add(diceSideSetter);
            diceStart.Add(followDice);
            diceStart.Add(auraParticle);
        }

        private void OnDestroy() => diceStart.RemoveAll();

        public void NotifyObservers() => diceStart.NotifyObservers();
    }
}