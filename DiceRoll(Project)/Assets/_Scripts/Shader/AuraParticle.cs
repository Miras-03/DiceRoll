using DiceSpace.CompleteObserver;
using DiceSpace.StartObserver;
using UnityEngine;

namespace ParticleSpace
{
    public sealed class AuraParticle : MonoBehaviour, IRollStartObserver, IRollCompleteObserver
    {
        [SerializeField] private ParticleSystem auraParticle;

        public void OnDiceRollStart() => auraParticle.Play();

        public void OnDiceRollCompleted() => auraParticle.Stop();
    }
}