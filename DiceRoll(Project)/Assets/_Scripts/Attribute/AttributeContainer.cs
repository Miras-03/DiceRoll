using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttributeSpace
{
    public class AttributeContainer
    {
        public Dictionary<string, int> attributesData = new Dictionary<string, int>();

        public void SetAttributeDates()
        {
            attributesData["Intellect"] = PlayerPrefs.GetInt("Intellect", 0);
            attributesData["Power"] = PlayerPrefs.GetInt("Power", 0);
            attributesData["Dexterity"] = PlayerPrefs.GetInt("Dexterity", 0);
        }

        public void LoseAttributeDates()
        {
            PlayerPrefs.SetInt("Intellect", 0);
            PlayerPrefs.SetInt("Power", 0);
            PlayerPrefs.SetInt("Dexterity", 0);
        }

        public int GetSum()
        {
            SetAttributeDates();
            return attributesData.Values.Sum();
        }
    }
}