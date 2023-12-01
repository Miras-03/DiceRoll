using TMPro;
using UnityEngine;

namespace DiceSpace
{
    public sealed class RollResult
    {
        private TextMeshProUGUI resultText;

        public RollResult(TextMeshProUGUI resultText) => this.resultText = resultText;

        public string ResultGame(int resultNumber, int difClass)
        {
            string result;

            if (resultNumber == 1)
                result = "Critical failure";
            else if (resultNumber == 20)
                result = "Critical success";
            else if (resultNumber >= difClass)
                result = "Success";
            else
                result = "Failure";

            SetColor(resultNumber, difClass);

            return result;
        }

        private void SetColor(int resultNumber, int difClass)
        {
            if (resultNumber >= difClass)
                resultText.color = Color.green;
            else
                resultText.color = Color.red;
        }
    }
}