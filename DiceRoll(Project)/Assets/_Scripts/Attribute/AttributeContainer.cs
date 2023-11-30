using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AttributeSpace
{
    public class AttributeContainer : IInitializable, IDisposable
    {
        public Dictionary<string, int> attributesData = new Dictionary<string, int>();

        private Action OnAttributeLose;

        public void Initialize() => OnAttributeLose += LoseAttributeDates;

        public void Dispose() => OnAttributeLose -= LoseAttributeDates;

        public void SetAttributeDates()
        {
            attributesData["Intellect"] = PlayerPrefs.GetInt("Intellect", 0);
            attributesData["Power"] = PlayerPrefs.GetInt("Power", 0);
            attributesData["Dexterity"] = PlayerPrefs.GetInt("Dexterity", 0);
        }

        public async void LoseAttributeDates()
        {
            await Task.Delay(500);
            PlayerPrefs.SetInt("Intellect", 0);
            PlayerPrefs.SetInt("Power", 0);
            PlayerPrefs.SetInt("Dexterity", 0);
        }

        public int GetSum()
        {
            OnAttributeLose.Invoke();
            SetAttributeDates();
            return attributesData.Values.Sum();
        }
    }
}