using DG.Tweening;
using UnityEngine;
using System;
using DiceSpace.StartObserver;

namespace DiceSpace
{
    public sealed class DiceRoll : IDiceStartObserver
    {
        public static Action OnRollComplete;

        private DicePath dicePath;
        private RectTransform diceTransform;

        public DiceRoll(RectTransform diceTransform, RectTransform pathParent)
        {
            this.diceTransform = diceTransform;
            dicePath = new DicePath(pathParent);
            dicePath.SetEdgePoints();
        }

        public void OnDiceRollStart() => Roll();

        public void Roll()
        {
            const int rollDuration = 3;

            diceTransform.
                DOPath(dicePath.DiceEdges, rollDuration, PathType.CatmullRom).SetEase(Ease.OutSine).
                OnComplete(() => OnRollComplete.Invoke());
        }
    }
}