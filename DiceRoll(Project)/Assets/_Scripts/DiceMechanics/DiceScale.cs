using UnityEngine;
using DG.Tweening;
using AttributeSpace;

namespace DiceSpace
{
    public sealed class DiceScale : IAttributeUseObserver
    {
        private RectTransform diceTransform;

        private Vector3 originScale;
        private Vector3 scaleTo;

        private const int durationTime = 1;

        public DiceScale(RectTransform diceTransform)
        {
            this.diceTransform = diceTransform;

            originScale = diceTransform.localScale;
            scaleTo = diceTransform.localScale*1.5f;
        }

        public void OnAttributeUse() => ScaleDice();

        public void ScaleDice()
        {
            diceTransform.DOScale(scaleTo, durationTime).
                OnComplete(() => diceTransform.DOScale(originScale, durationTime));
        }
    }
}