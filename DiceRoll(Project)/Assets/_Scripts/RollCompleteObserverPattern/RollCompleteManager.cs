using UnityEngine;
using UISpace;
using Zenject;
using ParticleSpace;

namespace DiceSpace.CompleteObserver
{
    public sealed class RollCompleteManager : MonoBehaviour
    {
        [Space(20)]
        [SerializeField] private RectTransform diceTransform;

        [Space(20)]
        [Header("Complete Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private AuraParticle auraParticle;
        [SerializeField] private SparkParticle punchParticle;
        private DiceSideSetter diceSideSetter;
        private RollComplete dice;
        private DicePunch dicePunch;
        private PlayButton playButton;

        [Inject]
        public void Constructor(PlayButton playButton) => this.playButton = playButton;

        private void Awake()
        {
            dice = new RollComplete();
            diceSideSetter = new DiceSideSetter(diceTransform);
            dicePunch = new DicePunch(diceTransform);
        }

        private void OnEnable()
        {
            dice.AddObserver(uiManager);
            dice.AddObserver(playButton);
            dice.AddObserver(diceSideSetter);
            dice.AddObserver(dicePunch);
            dice.AddObserver(auraParticle);
            dice.AddObserver(punchParticle);

            DiceRoll.OnRollComplete += NotifyObservers;
        }

        private void OnDisable()
        {
            dice.RemoveAllObservers();
            DiceRoll.OnRollComplete -= NotifyObservers;
        }

        private void NotifyObservers() => dice.NotifyObservers();
    }
}