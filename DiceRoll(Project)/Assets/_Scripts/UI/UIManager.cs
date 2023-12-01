using DiceSpace;
using DiceSpace.StartObserver;
using TMPro;
using UnityEngine;
using Zenject;
using AttributeSpace;
using System.Threading.Tasks;

namespace UISpace
{
    public class UIManager : MonoBehaviour, IRollStartObserver, IAttributeUseObserver
    {
        private TextMeshProUGUI resultText;
        private TextMeshProUGUI clickDiceText;
        private TextMeshProUGUI difClassText;

        private DiceEdge diceEdge;
        private DifficultyClass difClass;
        private RollResult rollResult;
        private PlayButton playButtonClass;

        [Inject]
        public void InjectClasses(DifficultyClass difClass, PlayButton playButtonClass, DiceEdge diceEdge) 
        {
            this.difClass = difClass;
            this.playButtonClass = playButtonClass;
            this.diceEdge = diceEdge;
        }

        [Inject]
        public void InjectUI(TextMeshProUGUI[] texts)
        {
            clickDiceText = texts[0];
            resultText = texts[1];
            difClassText = texts[2];
        }

        private void Awake() => rollResult = new RollResult(resultText);

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
            SetResultText(false);
        }

        public async void OnAttributeUse()
        {
            await Task.Delay(2000);
            ResultGame();
        }

        private void SetClickText(bool target) => clickDiceText.enabled = target;

        private void SetResultText(bool target) => resultText.enabled = target;

        private void ResultGame()
        {
            int resultNumber = diceEdge.EdgeNumber + 1;
            int difClassNum = difClass.RandomDifClass;

            resultText.text = rollResult.ResultGame(resultNumber, difClassNum);
            SetResultText(true);
        }
    }
}