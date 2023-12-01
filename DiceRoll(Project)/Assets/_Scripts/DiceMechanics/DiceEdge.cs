using AttributeSpace;
using System;
using Zenject;

namespace DiceSpace
{
    public sealed class DiceEdge : IAttributeUseObserver
    {
        private AttributeContainer attributeContainer;
        private DifficultyClass difClass;
        private UIPunch uiPunch;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 19;

        [Inject]
        public void Constructor(AttributeContainer attributeContainer, DifficultyClass difClass, UIPunch uiPunch)
        {
            this.uiPunch = uiPunch;
            this.attributeContainer = attributeContainer;
            this.difClass = difClass;
        }

        public void GenerateRandomNumber() => EdgeNumber = 9;

        public void OnAttributeUse()
        {
            int resultNumber = EdgeNumber + 1;
            int attributeSum = attributeContainer.GetSum();

            if (resultNumber < difClass.RandomDifClass)
            {
                EdgeNumber = Math.Min(EdgeNumber + attributeSum, diceEdgeCount);
                if (attributeSum > 0)
                    uiPunch.Punch();
            }
        }
    }
}