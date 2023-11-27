using DiceSpace;
using DiceSpace.StartObserver;
using DiceSpace.CompleteObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        private DiceEdgeSingleton randomDiceEdge;
        private DifficultyClass difClass;
        private RollResult rollResult;

        private void Awake()
        {
            difClass = new DifficultyClass();
            rollResult = new RollResult();
            randomDiceEdge = DiceEdgeSingleton.Instance;
        }

        private void Start()
        {
            difClass.GenerateDifClass();
            difClass.SetDifficultyClass(difClassText);
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
            SetTextMeshPro(true);
            SetButton(true);
        }

        public void SetTextMeshPro(bool target) => clickDiceText.enabled = target;

        public void SetButton(bool target) => rollButton.enabled = target;

        public void ResultGame()
        {
            resultText.enabled = true;

            int resultNumber = randomDiceEdge.EdgeNumber+1;
            int difClassNum = difClass.RandomDifClass;

            resultText.text = rollResult.ResultGame(resultText, resultNumber, difClassNum);
        }
    }
}