using TMPro;
using Zenject;
using DG.Tweening;
using AttributeSpace;

namespace UISpace
{
    public sealed class TextPunch
    {
        private TextMeshProUGUI intellectText;
        private TextMeshProUGUI powerText;
        private TextMeshProUGUI dexterityText;
        private AttributeUI attributeUI;

        [Inject]
        public void Constructor(TextMeshProUGUI[] texts, AttributeUI attributeUI)
        {
            intellectText = texts[4];
            powerText = texts[5];
            dexterityText = texts[6];
            this.attributeUI = attributeUI;
        }

        public void DoPunch()
        {
            UnityEngine.Vector3 punchVector = new UnityEngine.Vector3(5, 5, 5);

            if (attributeUI.IntellectIncluded)
                intellectText.rectTransform.DOPunchPosition(punchVector, 1);
            if (attributeUI.PowerIncluded)
                powerText.rectTransform.DOPunchPosition(punchVector, 1);
            if (attributeUI.DexternityIncluded)
                dexterityText.rectTransform.DOPunchPosition(punchVector, 1);
        }
    }
}