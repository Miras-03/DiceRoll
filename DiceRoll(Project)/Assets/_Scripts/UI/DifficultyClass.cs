using TMPro;
using UnityEngine;

public sealed class DifficultyClass
{
    private TextMeshProUGUI difficultyIndicator;

    private int[] difficultyNumbers = { 10, 15 };
    public int RandomDifClass { get; set; }

    public void Initialize() => GenerateDifClass();

    public void SetDifficultyClass(TextMeshProUGUI difficultyIndicator) => 
        this.difficultyIndicator = difficultyIndicator;

    public void ShowDifficulty() => difficultyIndicator.text = RandomDifClass.ToString();

    public void GenerateDifClass()
    {
        int rand = Random.Range(0, 2);
        RandomDifClass = difficultyNumbers[rand];
    }
}
