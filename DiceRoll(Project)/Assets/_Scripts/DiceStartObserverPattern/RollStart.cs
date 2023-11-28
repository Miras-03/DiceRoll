using System.Collections.Generic;

namespace DiceSpace.StartObserver
{
    public sealed class RollStart
    {
        private HashSet<IRollStartObserver> observers = new HashSet<IRollStartObserver>();

        public void Add(IRollStartObserver observer) => observers.Add(observer);

        public void RemoveAll() => observers.Clear();

        public void NotifyObservers()
        {
            foreach (IRollStartObserver observer in observers)
                observer.OnDiceRollStart();
        }
    }
}