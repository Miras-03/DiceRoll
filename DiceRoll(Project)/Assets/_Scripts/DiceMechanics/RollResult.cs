using TMPro;
using UnityEngine;

namespace DiceSpace
{
    public sealed class RollResult
    {
        public string ResultGame(TextMeshProUGUI text, int resultNumber, int difClass)
        {
            string result;

            text.color = Color.red;

            if (resultNumber == 1)
                result = "Critical failure";
            else if (resultNumber == 20)
                result = "Critical success";
            else if (resultNumber < difClass)
                result = "Failure";
            else
            {
                result = "Success";
                text.color = Color.green;
            }

            return result;
        }
    }
}