using DiceSpace;
using DiceSpace.CompleteObserver;
using DiceSpace.StartObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayButton : MonoBehaviour, IDiceStartObserver, IDiceCompleteObserver
{
    [Header("UI")]
    [SerializeField] private Button rollButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Image playButtonsImage;
    [SerializeField] private TextMeshProUGUI playButtonsText;

    private DiceEdge randomDiceEdge;
    private DifficultyClass difClass;

    [Inject]
    public void Constructor(DifficultyClass difClass)
    {
        this.difClass = difClass;
        randomDiceEdge = DiceEdge.Instance;
    }

    private void Start()
    {
        SetRollButton(true);
        SetPlayButton(false);
    }

    public void OnDiceRollStart()
    {
        SetRollButton(false);
        SetPlayButton(false);
    }

    public void OnDiceRollCompleted()
    {
        int resultNumber = randomDiceEdge.EdgeNumber+1;
        int difClassNum = difClass.RandomDifClass;

        if (resultNumber >= difClassNum)
        {
            SetRollButton(false);
            SetPlayButton(true);
        }
        else
        {
            SetRollButton(true);
            SetPlayButton(false);
        }
    }

    private void SetRollButton(bool enabled) => rollButton.enabled = enabled;

    private void SetPlayButton(bool enabled)
    {
        playButton.enabled = enabled;
        playButtonsImage.enabled = enabled;
        playButtonsText.enabled = enabled;
    }
}