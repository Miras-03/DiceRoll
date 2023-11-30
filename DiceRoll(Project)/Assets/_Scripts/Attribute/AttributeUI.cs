using UnityEngine;
using UnityEngine.UI;

namespace AttributeSpace
{
    public class AttributeUI : MonoBehaviour
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

        private AttributeIncrease attributeIncrease;

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