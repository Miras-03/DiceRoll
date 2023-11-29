using DiceSpace.StartObserver;
using DG.Tweening;
using UnityEngine;

namespace DiceSpace
{
    public sealed class FollowDice : IRollStartObserver
    {
        private RectTransform target;
        private RectTransform auraParticleTransform;

        private DicePath dicePath;

        private const int followSpeed = 7;

        public FollowDice(RectTransform target, RectTransform auraParticleTransform, RectTransform pathTransform)
        {
            dicePath = DicePath.Instance;
            dicePath.PathTransform = pathTransform;
            dicePath.SetEdgePoints();
            this.target = target;
            this.auraParticleTransform = auraParticleTransform;
        }

        public void OnDiceRollStart() => DelayAndFollow();

        private void DelayAndFollow()
        {
            auraParticleTransform.
                DOPath(dicePath.DiceEdges, followSpeed, PathType.CatmullRom).
                SetSpeedBased().
                SetEase(Ease.OutSine).
                SetLookAt(target);
        }
    }
}