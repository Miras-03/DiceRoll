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
        [Header("Start Observers")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private PlayButton playButton;
        private DiceSideSetter diceSideSetter;
        private DiceStart diceStart;
        private DiceRoll diceRoll;
        private DiceRotate diceRotate;

        private void Awake()
        {
            diceSideSetter = new DiceSideSetter(diceTransform);
            diceStart = new DiceStart();
            diceRoll = new DiceRoll(diceTransform, pathsParent);
            diceRotate = new DiceRotate(diceTransform);
        }

        private void OnEnable()
        {
            diceStart.Add(uiManager);
            diceStart.Add(playButton);
            diceStart.Add(diceRoll);
            diceStart.Add(diceRotate);
            diceStart.Add(diceSideSetter);
        }

        private void OnDestroy() => diceStart.RemoveAll();

        public void NotifyObservers() => diceStart.NotifyObservers();
    }
}