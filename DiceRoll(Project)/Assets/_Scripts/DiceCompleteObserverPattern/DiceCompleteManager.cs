using UnityEngine;
using UISpace;
using Zenject;

namespace DiceSpace.CompleteObserver
{
    public sealed class DiceCompleteManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private RectTransform diceTransform;

        [Header("Complete Observers")]
        [SerializeField] private UIManager uiManager;
        private DiceSideSetter diceSideSetter;
        private DiceComplete dice;
        private DicePunch dicePunch;
        private PlayButton playButton;

        [Inject]
        public void Constructor(PlayButton playButton) => this.playButton = playButton;

        private void Awake()
        {
            dice = new DiceComplete();
            diceSideSetter = new DiceSideSetter(diceTransform);
            dicePunch = new DicePunch(diceTransform);
        }

        private void OnEnable()
        {
            dice.AddObserver(uiManager);
            dice.AddObserver(playButton);
            dice.AddObserver(diceSideSetter);
            dice.AddObserver(dicePunch);

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