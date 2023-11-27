using UnityEngine;
using UISpace;

namespace DiceSpace.CompleteObserver
{
    public sealed class DiceCompleteManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private RectTransform diceTransform;

        [Header("Complete Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private PlayButton playButton;
        private DiceSideSetter diceSideSetter;

        private DiceComplete dice;
        private DicePunch dicePunch;

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