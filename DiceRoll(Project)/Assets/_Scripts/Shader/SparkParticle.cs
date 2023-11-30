using AttributeSpace;
using DiceSpace;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ParticleSpace
{
    public sealed class SparkParticle : MonoBehaviour, IAttributeUseObserver
    {
        [SerializeField] private ParticleSystem punchParticle;
        private DifficultyClass difClass;
        private DiceEdge diceEdge;

        private const int diceEdgeCount = 19;

        [Inject]
        public void Constructor(DifficultyClass difClass, DiceEdge diceEdge)
        {
            this.difClass = difClass;
            this.diceEdge = diceEdge;
        }

        public void OnAttributeUse() => CheckOrPunch();

        private async void CheckOrPunch()
        {
            int resultNumber = diceEdge.EdgeNumber;

            if (resultNumber >= difClass.RandomDifClass)
            {
                await Task.Delay(900);
                punchParticle.Play();
            }
        }
    }
}