using UnityEngine;
using Zenject;
using ParticleSpace;
using AttributeSpace;

namespace DiceSpace.CompleteObserver
{
    public sealed class RollCompleteManager : MonoBehaviour
    {
        [Space(20)]
        [SerializeField] private RectTransform diceTransform;

        [Space(20)]
        [Header("Complete Observers")]
        [SerializeField] private AuraParticle auraParticle;
        [SerializeField] private AttributeUseManager attributeUseManager;
        private DiceSideSetter sideSetter;
        private RollComplete dice;
        private DicePunch dicePunch;

        [Inject]
        public void Constructor(DiceSideSetter sideSetter) => this.sideSetter = sideSetter;

        private void Awake()
        {
            dice = new RollComplete();
            dicePunch = new DicePunch(diceTransform);
        }

        private void Start() => sideSetter.SetTransform(diceTransform);

        private void OnEnable()
        {
            dice.AddObserver(sideSetter);
            dice.AddObserver(dicePunch);
            dice.AddObserver(auraParticle);
            dice.AddObserver(attributeUseManager);

            DiceRoll.OnRollComplete += NotifyObservers;
        }

        private void OnDisable()
        {
            dice.RemoveAllObservers();
            DiceRoll.OnRollComplete -= NotifyObservers;
        }

        private void NotifyObservers() => dice.NotifyObservers();
    }
}