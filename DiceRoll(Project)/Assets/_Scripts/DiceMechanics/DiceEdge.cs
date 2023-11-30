using AttributeSpace;
using System;
using Zenject;

namespace DiceSpace
{
    public sealed class DiceEdge : IAttributeUseObserver
    {
        private AttributeContainer attributeContainer;
        private DifficultyClass difClass;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 19;

        [Inject]
        public void Constructor(AttributeContainer attributeContainer, DifficultyClass difClass)
        {
            this.attributeContainer = attributeContainer;
            this.difClass = difClass;
        }

        public void GenerateRandomNumber() => EdgeNumber = UnityEngine.Random.Range(0, diceEdgeCount);

        public void OnAttributeUse()
        {
            if (EdgeNumber < difClass.RandomDifClass)
                EdgeNumber = Math.Min(EdgeNumber + attributeContainer.GetSum(), diceEdgeCount);
        }
    }
}