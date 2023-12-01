using TMPro;
using Zenject;
using DG.Tweening;
using System.Threading.Tasks;

public class UIPunch
{
    private TextMeshProUGUI intellectText;
    private TextMeshProUGUI powerText;
    private TextMeshProUGUI dexterityText;

    [Inject]
    public void Constructor(TextMeshProUGUI[] texts)
    {
        intellectText = texts[4];
        powerText = texts[5];
        dexterityText = texts[6];
    }

    public async void Punch()
    {
        await Task.Delay(500);
        UnityEngine.Vector3 punchVector = new UnityEngine.Vector3(5, 5, 5);

        intellectText.rectTransform.DOPunchPosition(punchVector, 1);
        powerText.rectTransform.DOPunchPosition(punchVector, 1);
        dexterityText.rectTransform.DOPunchPosition(punchVector, 1);
    }
}