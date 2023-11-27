using UnityEngine;
using UISpace;

namespace DiceSpace.StartObserver
{
    public sealed class DiceStartManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private RectTransform diceTransform;
        [SerializeField] private RectTransform pathsParent;

        [Space(20)]
        [SerializeField] private UIManager uiManager;
        private DiceStart diceStart;
        private DiceRoll diceRoll;
        private DiceRotate diceRotate;

        private void Awake()
        {
            diceStart = new DiceStart();
            diceRoll = new DiceRoll(diceTransform, pathsParent);
            diceRotate = new DiceRotate(diceTransform);
        }

        private void OnEnable()
        {
            diceStart.Add(uiManager);
            diceStart.Add(diceRoll);
            diceStart.Add(diceRotate);
        }

        private void OnDestroy() => diceStart.RemoveAll();

        public void NotifyObservers() => diceStart.NotifyObservers();
    }
}