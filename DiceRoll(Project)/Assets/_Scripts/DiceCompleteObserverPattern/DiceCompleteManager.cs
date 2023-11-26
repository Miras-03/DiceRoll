using UnityEngine;

namespace DiceOption.Observer
{
    public sealed class DiceCompleteManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private RectTransform diceTransform;

        private DiceComplete dice;
        private DicePunch dicePunch;
        private DiceSideSetter diceSideSetter;

        private void Awake()
        {
            dice = new DiceComplete();

            dicePunch = new DicePunch(diceTransform);
            diceSideSetter = new DiceSideSetter(diceTransform);
        }

        private void OnEnable()
        {
            dice.AddObserver(diceSideSetter);
            dice.AddObserver(dicePunch);
            dice.AddObserver(uiManager);

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