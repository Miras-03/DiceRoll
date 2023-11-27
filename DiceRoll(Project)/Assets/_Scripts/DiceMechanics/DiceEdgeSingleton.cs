using UnityEngine;

namespace DiceSpace
{
    public sealed class DiceEdgeSingleton
    {
        private static DiceEdgeSingleton instance;

        public int EdgeNumber { get; set; }
        private const int diceEdgeCount = 20;

        public static DiceEdgeSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiceEdgeSingleton();
                return instance;
            }
        }

        public int GenerateRandomNumber() => EdgeNumber = Random.Range(0, diceEdgeCount);
    }
}