using AttributeSpace;
using DiceSpace;
using DiceSpace.StartObserver;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class PlayButton : IInitializable, IDisposable, IRollStartObserver, IAttributeUseObserver
{
    private Button rollButton;
    private Button playButton;

    private TextMeshProUGUI clickDiceText;
    private TextMeshProUGUI playButtonsText;

    private Image playButtonsImage;

    private DiceEdge diceEdge;
    private DifficultyClass difClass;

    [Inject]
    public void InjectClasses(DifficultyClass difClass, DiceEdge diceEdge)
    {
        this.difClass = difClass;
        this.diceEdge = diceEdge;
    }

    [Inject]
    public void InjectUI(Button[] buttons, TextMeshProUGUI[] texts, Image[] images) {
        rollButton = buttons[0];
        playButton = buttons[1];

        clickDiceText = texts[0];
        playButtonsText = texts[3];

        playButtonsImage = images[0];
    }

    public void Initialize() => playButton.onClick.AddListener(Play);

    public void Dispose() => playButton.onClick.RemoveListener(Play);

    public void Play()
    {
        difClass.GenerateDifClass();
        difClass.ShowDifficulty();

        SetClickText(true);
        SetRollButton(true);
        SetPlayButton(false);
    }

    public void OnDiceRollStart()
    {
        SetRollButton(false);
        SetPlayButton(false);
    }

    public async void OnAttributeUse()
    {
        await Task.Delay(2000);
        int resultNumber = diceEdge.EdgeNumber + 1;
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
            SetClickText(true);
        }
    }

    public void SetPlayButton(bool enabled)
    {
        playButton.enabled = enabled;
        playButtonsImage.enabled = enabled;
        playButtonsText.enabled = enabled;
    }

    private void SetClickText(bool target) => clickDiceText.enabled = target;

    private void SetRollButton(bool enabled) => rollButton.enabled = enabled;
}