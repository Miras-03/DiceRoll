using DG.Tweening;
using System;
using UnityEngine;

namespace DiceOption
{
    public sealed class DiceRotate : IDisposable
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

        private void OnDiceRollCompleted() => Kill();

        public void Rotate()
        {
            rotateTweener = diceTransform.DORotate(rotateVec, speed).
                SetSpeedBased().
                SetEase(Ease.Linear).
                SetLoops(-1);
        }

        public void Kill() => rotateTweener.Kill();
    }
}