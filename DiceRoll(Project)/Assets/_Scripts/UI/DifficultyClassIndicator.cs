using TMPro;
using UnityEngine;

public sealed class DifficultyClassIndicator
{
    private TextMeshProUGUI difficultyIndicator;

    public DifficultyClassIndicator(TextMeshProUGUI difficultyIndicator) => 
        this.difficultyIndicator = difficultyIndicator;

    public void ShowDifficulty()
    {
        int[] difficultyNumbers = { 10, 15 };
        int randomNumber = Random.Range(0, 2);

        difficultyIndicator.text = difficultyNumbers[randomNumber].ToString();
    }
}
