using UnityEngine;

namespace DiceSpace
{
    public class DiceEdge
    {
        private static DiceEdge instance;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 20;

        public static DiceEdge Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiceEdge();
                return instance;
            }
        }

        public void GenerateRandomNumber() => EdgeNumber = Random.Range(0, diceEdgeCount);
    }
}