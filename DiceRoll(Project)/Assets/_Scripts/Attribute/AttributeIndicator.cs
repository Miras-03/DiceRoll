using TMPro;
using UnityEngine;

namespace AttributeSpace
{
    public class AttributeIndicator : MonoBehaviour
    {
        [Space(20)]
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI intellectText;
        [SerializeField] private TextMeshProUGUI powerText;
        [SerializeField] private TextMeshProUGUI dexterityText;

        private AttributeContainer attributeContainer;

        private void Start()
        {
            SetAttributeValues();
            SetTexts();
        }

        public void SetAttributeValues()
        {
            attributeContainer.Intellect = PlayerPrefs.GetInt("Intellect", 0);
            attributeContainer.Power = PlayerPrefs.GetInt("Power", 0);
            attributeContainer.Dexterity = PlayerPrefs.GetInt("Dexterity", 0);
        }

        public void SetTexts()
        {
            intellectText.text = $"Intellect: {attributeContainer.Intellect}";
            powerText.text = $"Power: {attributeContainer.Power}";
            dexterityText.text = $"Dexterity: {attributeContainer.Dexterity}";
        }
    }
}