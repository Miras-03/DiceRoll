using System.Collections.Generic;

namespace DiceSpace.StartObserver
{
    public sealed class DiceStart
    {
        private HashSet<IDiceStartObserver> observers = new HashSet<IDiceStartObserver>();

        public void Add(IDiceStartObserver observer) => observers.Add(observer);

        public void RemoveAll() => observers.Clear();

        public void NotifyObservers()
        {
            foreach (IDiceStartObserver observer in observers)
                observer.OnDiceRollStart();
        }
    }
}