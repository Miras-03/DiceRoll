using UnityEngine;
using UISpace;
using Zenject;

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
        private DiceSideSetter diceSideSetter;
        private DiceRotate diceRotate;
        private DiceRoll diceRoll;
        private DiceStart diceStart;
        private PlayButton playButton;

        [Inject]
        public void Constructor(PlayButton playButton) => this.playButton = playButton;

        private void Awake()
        {
            diceSideSetter = new DiceSideSetter(diceTransform);
            diceRotate = new DiceRotate(diceTransform);
            diceRoll = new DiceRoll(diceTransform, pathsParent);
            diceStart = new DiceStart();
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