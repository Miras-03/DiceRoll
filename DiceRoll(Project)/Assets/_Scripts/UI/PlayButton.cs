using DiceSpace;
using DiceSpace.CompleteObserver;
using DiceSpace.StartObserver;
using System;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class PlayButton : IDisposable, IRollStartObserver, IRollCompleteObserver
{
    private Button rollButton;
    private Button playButton;

    private TextMeshProUGUI clickDiceText;
    private TextMeshProUGUI resultText;
    private TextMeshProUGUI playButtonsText;

    private Image playButtonsImage;

    private DiceEdge randomDiceEdge;
    private DifficultyClass difClass;

    [Inject]
    public void InjectClasses(DifficultyClass difClass)
    {
        this.difClass = difClass;
        randomDiceEdge = DiceEdge.Instance;
    }

    [Inject]
    public void InjectUI(Button[] buttons, TextMeshProUGUI[] texts, Image[] images) {
        rollButton = buttons[0];
        playButton = buttons[1];

        clickDiceText = texts[0];
        resultText = texts[1];
        playButtonsText = texts[3];

        playButtonsImage = images[0];

        playButton.onClick.AddListener(Play);
    }

    public void Dispose() => playButton.onClick.RemoveListener(Play);

    public void Play()
    {
        difClass.GenerateDifClass();
        difClass.ShowDifficulty();

        SetClickText(true);
        SetResultText(false);
        SetRollButton(true);
        SetPlayButton(false);
    }

    public void OnDiceRollStart()
    {
        SetRollButton(false);
        SetPlayButton(false);
        SetResultText(false);
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

    public void SetPlayButton(bool enabled)
    {
        playButton.enabled = enabled;
        playButtonsImage.enabled = enabled;
        playButtonsText.enabled = enabled;
    }

    private void SetClickText(bool target) => clickDiceText.enabled = target;

    private void SetResultText(bool target) => resultText.enabled = target;

    private void SetRollButton(bool enabled) => rollButton.enabled = enabled;
}