using DiceSpace;
using DiceSpace.CompleteObserver;
using UnityEngine;
using Zenject;

namespace ParticleSpace
{
    public sealed class SparkParticle : MonoBehaviour, IRollCompleteObserver
    {
        [SerializeField] private ParticleSystem punchParticle;
        private DifficultyClass difClass;
        private DiceEdge randomDiceEdge;

        [Inject]
        public void InjectClasses(DifficultyClass difClass)
        {
            this.difClass = difClass;
            randomDiceEdge = DiceEdge.Instance;
        }

        public void OnDiceRollCompleted() => CheckOrPunch();

        private void CheckOrPunch()
        {
            int resultNumber = randomDiceEdge.EdgeNumber + 1;
            int difClassNum = difClass.RandomDifClass;

            if (resultNumber >= difClassNum)
                punchParticle.Play();

            var main = punchParticle.main;
            main.loop = false;
        }
    }
}