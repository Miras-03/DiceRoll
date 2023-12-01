using UISpace;
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
        private TextPunch textPunch;
        private TextColor textColor;

        [Inject]
        public void Constructor(AttributeIndicator attributeIndicator, TextPunch textPunch, TextColor textColor)
        {
            this.attributeIndicator = attributeIndicator;
            this.textPunch = textPunch;
            this.textColor = textColor;
        }

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
            attributeIncrease.CheckOrIncreaseIntellect(IntellectIncluded);
            attributeIncrease.CheckOrIncreasePower(PowerIncluded);
            attributeIncrease.CheckOrIncreaseDexterity(DexternityIncluded);

            textPunch.DoPunch();
            textColor.DoColor(Color.magenta);

            attributeIndicator.SetTexts();
        }

        public void SetIntellect(bool included) => IntellectIncluded = included;
        public void SetPower(bool included) => PowerIncluded = included;
        public void SetDexternity(bool included) => DexternityIncluded = included;

        public bool IntellectIncluded = false;
        public bool PowerIncluded = false;
        public bool DexternityIncluded = false;
    }
}