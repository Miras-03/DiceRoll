using DG.Tweening;
using DiceSpace.StartObserver;
using System;
using UnityEngine;

namespace DiceSpace
{
    public sealed class DiceRotate : IDiceStartObserver, IDisposable
    {
        private Tween rotateTweener;
        private RectTransform diceTransform;
        private Vector3 rotateVec = new Vector3(0, 300, 0);

        private const int speed = 1500;

        public DiceRotate(RectTransform diceTransform)
        {
            this.diceTransform = diceTransform;
            DiceRoll.OnRollComplete += OnDiceRollCompleted;
        }

        public void Dispose() => DiceRoll.OnRollComplete -= OnDiceRollCompleted;

        public void OnDiceRollStart() => Rotate();

        private void OnDiceRollCompleted() => Kill();

        public void Rotate()
        {
            rotateTweener = diceTransform.DORotate(rotateVec, speed,RotateMode.FastBeyond360).
                SetSpeedBased().
                SetEase(Ease.Linear).
                SetLoops(-1);
        }

        public void Kill() => rotateTweener.Kill();
    }
}