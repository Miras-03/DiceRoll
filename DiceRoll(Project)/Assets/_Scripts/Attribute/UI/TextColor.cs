using AttributeSpace;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class TextColor
{
    private TextMeshProUGUI intellectText;
    private TextMeshProUGUI powerText;
    private TextMeshProUGUI dexterityText;
    private AttributeUI attributeUI;

    private Color originColor = Color.green;

    private const int durationTime = 1;

    [Inject]
    public void Constructor(TextMeshProUGUI[] texts, AttributeUI attributeUI)
    {
        intellectText = texts[4];
        powerText = texts[5];
        dexterityText = texts[6];
        this.attributeUI = attributeUI;
    }

    public void DoColor( Color targetColor)
    {
        Vector3 punchVector = new Vector3(5, 5, 5);

        if (attributeUI.IntellectIncluded)
            intellectText.DOColor(targetColor, durationTime).
                OnComplete(()=>intellectText.DOColor(originColor, durationTime));
        if (attributeUI.PowerIncluded)
            powerText.DOColor(targetColor, durationTime).
                OnComplete(() => powerText.DOColor(originColor, durationTime));
        if (attributeUI.DexternityIncluded)
            dexterityText.DOColor(targetColor, durationTime).
                OnComplete(() => dexterityText.DOColor(originColor, durationTime));
    }
}
