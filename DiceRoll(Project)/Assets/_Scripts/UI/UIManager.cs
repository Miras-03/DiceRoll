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
        [SerializeField] private Button rollButton;

        [Space(20)]
        [Header("UI Texts")]
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private TextMeshProUGUI clickDiceText;
        [SerializeField] private TextMeshProUGUI difClassText;

        private DiceEdge randomDiceEdge;
        private DifficultyClass difClass;
        private RollResult rollResult;

        [Inject]
        public void Constructor(DifficultyClass difClass)
        {
            this.randomDiceEdge = DiceEdge.Instance;
            this.difClass = difClass;

            rollResult = new RollResult(resultText, clickDiceText);
        }

        private void Start()
        {
            difClass.SetDifficultyClass(difClassText);
            difClass.GenerateDifClass();
            difClass.ShowDifficulty();
        }

        public void Play()
        {
            difClass.GenerateDifClass();
            difClass.ShowDifficulty();
        }

        public void OnDiceRollStart()
        {
            resultText.enabled = false;
            SetTextMeshPro(false);
            SetButton(false);
        }

        public void OnDiceRollCompleted()
        {
            ResultGame();
            SetButton(true);
        }

        public void SetTextMeshPro(bool target) => clickDiceText.enabled = target;

        public void SetButton(bool target) => rollButton.enabled = target;

        public void ResultGame()
        {
            resultText.enabled = true;

            int resultNumber = randomDiceEdge.EdgeNumber + 1;
            int difClassNum = difClass.RandomDifClass;

            resultText.text = rollResult.ResultGame(resultNumber, difClassNum);
        }
    }
}