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

        [Inject]
        public void Constructor(AttributeIndicator attributeIndicator) => 
            this.attributeIndicator = attributeIndicator;

        private void Awake()
        {
            increaseButton.onClick.AddListener(Increase);

            attributeIncrease = new AttributeIncrease();
        }

        public void Increase()
        {
            attributeIncrease.CheckOrIncreaseIntellect(intellectToggle);
            attributeIncrease.CheckOrIncreasePower(powerToggle);
            attributeIncrease.CheckOrIncreaseDexterity(dexternityToggle);

            attributeIndicator.SetTexts();
        }
    }
}