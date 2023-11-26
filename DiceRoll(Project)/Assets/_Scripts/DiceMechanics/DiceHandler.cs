using TMPro;
using UnityEngine;

namespace DiceOption
{
    public sealed class DiceHandler : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        private DifficultyClassIndicator difIndicator;

        [Space(20)]
        [Header("UI Elements")]
        [SerializeField] private RectTransform diceTransform;
        [SerializeField] private RectTransform pathsParent;
        [SerializeField] private TextMeshProUGUI difClassText;

        private DiceRoll diceRoll;

        private void Awake()
        {
            difIndicator = new DifficultyClassIndicator(difClassText);
            diceRoll = new DiceRoll(diceTransform, pathsParent);
        }

        private void Start()
        {
            difIndicator.ShowDifficulty();
        }

        public void RollDice()
        {
            uiManager.SetTextMeshPro(false);
            uiManager.SetButton(false);

            diceRoll.Roll();
        }
    }
}