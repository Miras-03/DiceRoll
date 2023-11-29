using UnityEngine;

namespace DiceSpace
{
    public sealed class DicePath
    {
        private static DicePath instance;

        public static DicePath Instance
        {
            get
            {
                if (instance == null)
                    instance = new DicePath();
                return instance;
            }
        }

        public void SetEdgePoints()
        {
            int diceEdgeCount = PathTransform.childCount + 1;

            DiceEdges = new Vector3[diceEdgeCount];

            for (int i = 0; i < diceEdgeCount-1; i++)
                DiceEdges[i] = PathTransform.GetChild(i).position;

            DiceEdges[diceEdgeCount-1] = PathTransform.position;
        }

        public RectTransform PathTransform { get; set; }

        public Vector3[] DiceEdges { get; set; }
    }
}