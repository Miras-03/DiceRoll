using DG.Tweening;
using UnityEngine;
using System;
using DiceSpace.StartObserver;
using Zenject;

namespace DiceSpace
{
    public sealed class DiceRoll : IRollStartObserver
    {
        public static Action OnRollComplete;

        private DicePath dicePath;
        private RectTransform diceTransform;

        private const int rollDuration = 3;

        public DiceRoll(RectTransform diceTransform, RectTransform pathParent)
        {
            this.diceTransform = diceTransform;
            dicePath = DicePath.Instance;
            dicePath.SetParent(pathParent);
            dicePath.SetEdgePoints();
        }

        public void OnDiceRollStart() => Roll();

        public void Roll()
        {
            diceTransform.
                DOPath(dicePath.DiceEdges, rollDuration, PathType.CatmullRom).
                SetEase(Ease.OutSine).
                OnComplete(() => OnRollComplete.Invoke());
        }
    }
}