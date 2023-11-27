using System.Collections.Generic;

namespace DiceSpace.CompleteObserver
{
    public sealed class DiceComplete
    {
        private HashSet<IDiceCompleteObserver> diceObservers = new HashSet<IDiceCompleteObserver>();

        public void AddObserver(IDiceCompleteObserver observer) => diceObservers.Add(observer);
        public void RemoveAllObservers() => diceObservers.Clear();

        public void NotifyObservers()
        {
            foreach (IDiceCompleteObserver observer in diceObservers)
                observer.OnDiceRollCompleted();
        }
    }
}