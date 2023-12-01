using AttributeSpace;
using System;
using UISpace;
using UnityEngine;
using Zenject;

namespace DiceSpace
{
    public sealed class DiceEdge : IAttributeUseObserver
    {
        private AttributeContainer attributeContainer;
        private DifficultyClass difClass;
        private AttributeIndicator attributeIndicator;
        private TextPunch textPunch;
        private TextColor textColor;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 19;

        [Inject]
        public void Constructor(DifficultyClass difClass, AttributeContainer attributeContainer,
            AttributeIndicator attributeIndicator, TextPunch textPunch, TextColor textColor)
        {
            this.difClass = difClass;
            this.attributeContainer = attributeContainer;
            this.attributeIndicator = attributeIndicator;
            this.textPunch = textPunch;
            this.textColor = textColor;
        }

        public void GenerateRandomNumber() => EdgeNumber = UnityEngine.Random.Range(0, diceEdgeCount);

        public void OnAttributeUse()
        {
            int resultNumber = EdgeNumber + 1;
            int attributeSum = attributeContainer.GetSum();

            if (resultNumber < difClass.RandomDifClass)
            {
                EdgeNumber = Math.Min(EdgeNumber + attributeSum, diceEdgeCount);
                CheckOrPunchAttribute();
            }
        }

        private void CheckOrPunchAttribute()
        {
            int attributeSum = attributeContainer.GetSum();

            if (attributeSum > 0)
            {
                textPunch.DoPunch();
                textColor.DoColor(Color.red);
                attributeContainer.LoseAttributeDates();
                attributeIndicator.SetTexts();
            }
        }
    }
}