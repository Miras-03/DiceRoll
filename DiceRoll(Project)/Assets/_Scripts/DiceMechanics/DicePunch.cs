using AttributeSpace;
using DG.Tweening;
using DiceSpace.CompleteObserver;
using UnityEngine;
using Zenject;

namespace DiceSpace
{
    public sealed class DicePunch : IRollCompleteObserver
    {
        private RectTransform diceTransform;

        public DicePunch(RectTransform diceTransform) => this.diceTransform = diceTransform;

        public void OnDiceRollCompleted() => Punch();

        public void Punch()
        {
            Vector3 punchVector = new Vector3(15, 15, 15);
            diceTransform.DOPunchRotation(punchVector, 1);
        }
    }
}