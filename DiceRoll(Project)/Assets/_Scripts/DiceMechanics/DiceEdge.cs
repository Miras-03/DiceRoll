using AttributeSpace;
using System;
using Zenject;

namespace DiceSpace
{
    public sealed class DiceEdge : IAttributeUseObserver
    {
        private AttributeContainer attributeContainer;
        private DiceEdge diceEdge;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 19;

        [Inject]
        public void Constructor(AttributeContainer attributeContainer, DiceEdge diceEdge)
        {
            this.attributeContainer = attributeContainer;
            this.diceEdge = diceEdge;
        }

        public void GenerateRandomNumber() => EdgeNumber = UnityEngine.Random.Range(0, diceEdgeCount);

        public void OnAttributeUse()
        {
            int resultNumber = diceEdge.EdgeNumber;

            if (resultNumber != 0 && resultNumber != diceEdgeCount)
                EdgeNumber = Math.Min(EdgeNumber + attributeContainer.GetSum(), diceEdgeCount);
        }
    }
}