using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AttributeSpace
{
    public sealed class AttributeUI : MonoBehaviour
    {
        [Space(20)]
        [Header("Buttons")]
        [SerializeField] private Button increaseButton;

        [Space(20)]
        [Header("AttributeToggles")]
        [SerializeField] private Toggle intellectToggle;
        [SerializeField] private Toggle powerToggle;
        [SerializeField] private Toggle dexternityToggle;

        private AttributeIncrease attributeIncrease;
        private AttributeIndicator attributeIndicator;

        private bool intellectIncluded = false;
        private bool powerIncluded = false;
        private bool dexternityIncluded = false;

        [Inject]
        public void Constructor(AttributeIndicator attributeIndicator) => 
            this.attributeIndicator = attributeIndicator;

        private void Awake()
        {
            increaseButton.onClick.AddListener(Increase);
            AddButtonListener();
            MarkFalseToggles();
            AddToggleListeners();

            attributeIncrease = new AttributeIncrease();
        }

        private void AddButtonListener() => increaseButton.onClick.AddListener(Increase);

        private void MarkFalseToggles()
        {
            intellectToggle.isOn = false;
            powerToggle.isOn = false;
            dexternityToggle.isOn = false;
        }

        private void AddToggleListeners()
        {
            intellectToggle.onValueChanged.AddListener(SetIntellect);
            powerToggle.onValueChanged.AddListener(SetPower);
            dexternityToggle.onValueChanged.AddListener(SetDexternity);
        }

        public void Increase()
        {
            attributeIncrease.CheckOrIncreaseIntellect(intellectIncluded);
            attributeIncrease.CheckOrIncreasePower(powerIncluded);
            attributeIncrease.CheckOrIncreaseDexterity(dexternityIncluded);

            attributeIndicator.SetTexts();
        }

        public void SetIntellect(bool included) => intellectIncluded = included;
        public void SetPower(bool included) => powerIncluded = included;
        public void SetDexternity(bool included) => dexternityIncluded = included;
    }
}