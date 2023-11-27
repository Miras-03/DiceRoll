using UnityEngine;

namespace DiceSpace
{
    public sealed class DicePath
    {
        private RectTransform pathParent;

        private Vector3[] diceEdges;

        public DicePath(RectTransform pathParent) => this.pathParent = pathParent;

        public void SetEdgePoints()
        {
            int diceEdgeCount = pathParent.childCount + 1;

            diceEdges = new Vector3[diceEdgeCount];

            for (int i = 0; i < diceEdgeCount-1; i++)
                diceEdges[i] = pathParent.GetChild(i).position;

            diceEdges[diceEdgeCount-1] = pathParent.position;
        }

        public Vector3[] DiceEdges => diceEdges;
    }
}