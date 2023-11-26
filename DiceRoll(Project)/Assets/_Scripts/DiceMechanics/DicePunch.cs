using DG.Tweening;
using UnityEngine;

namespace DiceOption
{
    public sealed class DicePunch : IDiceCompleteObserver
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