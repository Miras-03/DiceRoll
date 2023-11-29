using UnityEngine;
using UnityEngine.UI;

namespace AttributeSpace
{
    public class AttributeIncrease : MonoBehaviour
    {
        [Space(20)]
        [Header("Scripts")]
        [SerializeField] private AttributeIndicator attributeIndicator;

        [Space(20)]
        [Header("Buttons")]
        [SerializeField] private Button increaseButton;

        [Space(20)]
        [Header("AttributeToggles")]
        [SerializeField] private Toggle intellectToggle;
        [SerializeField] private Toggle powerToggle;
        [SerializeField] private Toggle dexternityToggle;

        private const int maxAttributeLevel = 5;

        private bool intellect = true;
        private bool power = true;
        private bool dexterity = true;

        private void Awake()
        {
            increaseButton.onClick.AddListener(Increase);

            intellectToggle.onValueChanged.AddListener(IncludeIntellect);
            powerToggle.onValueChanged.AddListener(IncludePower);
            dexternityToggle.onValueChanged.AddListener(IncludeDexterity);
        }

        public void IncludeIntellect(bool included) => intellect = included;

        public void IncludePower(bool included) => power = included;

        public void IncludeDexterity(bool included) => dexterity = included;

        public void Increase()
        {
            CheckOrIncreaseIntellect();
            CheckOrIncreasePower();
            CheckOrIncreaseDexterity();

            attributeIndicator.SetAttributeValues();
            attributeIndicator.SetTexts();
        }

        private void CheckOrIncreaseIntellect()
        {
            if (intellect)
                PlayerPrefs.SetInt("Intellect", maxAttributeLevel);
        }

        private void CheckOrIncreasePower()
        {
            if (power)
                PlayerPrefs.SetInt("Power", maxAttributeLevel);
        }

        private void CheckOrIncreaseDexterity()
        {
            if (dexterity)
                PlayerPrefs.SetInt("Dexterity", maxAttributeLevel);
        }
    }
}