using TMPro;
using UnityEngine;
using Zenject;

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

        [Inject]
        public void Constructor(AttributeContainer attributeContainer) => 
            this.attributeContainer = attributeContainer;

        private void Start()
        {
            attributeContainer.SetAttributeDates();
            SetTexts();
        }

        public void SetTexts()
        {
            intellectText.text = $"Intellect: {attributeContainer.attributesData["Intellect"]}";
            powerText.text = $"Power: {attributeContainer.attributesData["Power"]}";
            dexterityText.text = $"Dexterity: {attributeContainer.attributesData["Dexterity"]}";
        }
    }
}