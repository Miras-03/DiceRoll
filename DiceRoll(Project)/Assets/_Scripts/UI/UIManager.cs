using DiceSpace;
using DiceSpace.StartObserver;
using DiceSpace.CompleteObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UISpace
{
    public class UIManager : MonoBehaviour, IDiceStartObserver, IDiceCompleteObserver
    {
        private Button rollButton;

        private TextMeshProUGUI resultText;
        private TextMeshProUGUI clickDiceText;
        private TextMeshProUGUI difClassText;

        private DiceEdge randomDiceEdge;
        private DifficultyClass difClass;
        private RollResult rollResult;
        private PlayButton playButtonClass;

        [Inject]
        public void InjectClasses(DifficultyClass difClass, PlayButton playButtonClass) 
        {
            this.difClass = difClass;
            this.playButtonClass = playButtonClass;
            randomDiceEdge = DiceEdge.Instance;
        }

        [Inject]
        public void InjectUI(Button[] buttons, TextMeshProUGUI[] texts)
        {
            rollButton = buttons[0];

            clickDiceText = texts[0];
            resultText = texts[1];
            difClassText = texts[2];

            rollResult = new RollResult(resultText, clickDiceText);
        }

        private void Start()
        {
            playButtonClass.SetPlayButton(false);

            difClass.SetDifficultyClass(difClassText);
            difClass.GenerateDifClass();
            difClass.ShowDifficulty();
        }

        public void OnDiceRollStart()
        {
            SetClickText(false);
            SetRollButton(false);
        }

        public void OnDiceRollCompleted()
        {
            ResultGame();
            SetRollButton(true);
        }

        private void SetClickText(bool target) => clickDiceText.enabled = target;

        private void SetRollButton(bool target) => rollButton.enabled = target;

        private void ResultGame()
        {
            resultText.enabled = true;

            int resultNumber = randomDiceEdge.EdgeNumber + 1;
            int difClassNum = difClass.RandomDifClass;

            resultText.text = rollResult.ResultGame(resultNumber, difClassNum);
        }
    }
}