using System.Collections.Generic;

namespace DiceSpace.CompleteObserver
{
    public sealed class RollComplete
    {
        private HashSet<IRollCompleteObserver> diceObservers = new HashSet<IRollCompleteObserver>();

        public void AddObserver(IRollCompleteObserver observer) => diceObservers.Add(observer);
        public void RemoveAllObservers() => diceObservers.Clear();

        public void NotifyObservers()
        {
            foreach (IRollCompleteObserver observer in diceObservers)
                observer.OnDiceRollCompleted();
        }
    }
}