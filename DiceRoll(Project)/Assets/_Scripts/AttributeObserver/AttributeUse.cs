using System.Collections.Generic;

namespace AttributeSpace
{
    public sealed class AttributeUse
    {
        private Dictionary<int, IAttributeUseObserver> observers = new Dictionary<int, IAttributeUseObserver>();

        public void AddObserver(int key, IAttributeUseObserver observer) => observers.Add(key, observer);
        
        public void RemoveAllObservers() => observers.Clear();

        public void NotifyObservers()
        {
            foreach (int key in observers.Keys)
                observers[key].OnAttributeUse();
        }
    }
}