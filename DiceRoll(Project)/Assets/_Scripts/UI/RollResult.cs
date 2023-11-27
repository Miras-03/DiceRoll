using TMPro;
using UnityEngine;

namespace DiceSpace
{
    public sealed class RollResult
    {
        private TextMeshProUGUI resultText;
        private TextMeshProUGUI clickButtonText;

        public RollResult(TextMeshProUGUI resultText, TextMeshProUGUI clickButtonText)
        {
            this.resultText = resultText;
            this.clickButtonText = clickButtonText;
        }

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
            {
                resultText.color = Color.green;
                clickButtonText.enabled = false;
            }
            else
            {
                resultText.color = Color.red;
                clickButtonText.enabled = true;
            }
        }
    }
}