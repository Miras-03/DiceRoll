using TMPro;
using Zenject;

namespace AttributeSpace
{
    public class AttributeIndicator
    {
        private TextMeshProUGUI intellectText;
        private TextMeshProUGUI powerText;
        private TextMeshProUGUI dexterityText;

        private AttributeContainer attributeContainer;

        [Inject]
        public void Constructor(AttributeContainer attributeContainer, TextMeshProUGUI[] texts)
        {
            this.attributeContainer = attributeContainer;

            intellectText = texts[4];
            powerText = texts[5];
            dexterityText = texts[6];

            SetTexts();
        }

        public void SetTexts()
        {
            attributeContainer.SetAttributeDates();
            intellectText.text = $"Intellect: {attributeContainer.attributesData["Intellect"]}";
            powerText.text = $"Power: {attributeContainer.attributesData["Power"]}";
            dexterityText.text = $"Dexterity: {attributeContainer.attributesData["Dexterity"]}";
        }
    }
}