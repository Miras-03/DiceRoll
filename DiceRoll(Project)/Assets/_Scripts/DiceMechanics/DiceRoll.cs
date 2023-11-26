using DG.Tweening;
using UnityEngine;
using System;

namespace DiceOption
{
    public sealed class DiceRoll
    {
        public static Action OnRollComplete;

        private DiceRotate diceRotate;
        private DicePath dicePath;
        private RectTransform diceTransform;

        public DiceRoll(RectTransform diceTransform, RectTransform pathParent)
        {
            this.diceTransform = diceTransform;

            diceRotate = new DiceRotate(diceTransform);
            dicePath = new DicePath(pathParent);

            dicePath.SetEdgePoints();
        }

        public void Roll()
        {
            const int rollDuration = 3;

            diceTransform.
                DOPath(dicePath.DiceEdges, rollDuration, PathType.CatmullRom).SetEase(Ease.OutSine).
                OnComplete(() => diceRotate.Kill()).
                OnComplete(() => OnRollComplete.Invoke());

            diceRotate.Rotate();
        }
    }
}