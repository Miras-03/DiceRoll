using UnityEngine;

public class AttributeIncrease
{
    private const int maxAttributeLevel = 5;

    public void CheckOrIncreaseIntellect(bool included)
    {
        if (included)
            PlayerPrefs.SetInt("Intellect", maxAttributeLevel);
    }

    public void CheckOrIncreasePower(bool included)
    {
        if (included)
            PlayerPrefs.SetInt("Power", maxAttributeLevel);
    }

    public void CheckOrIncreaseDexterity(bool included)
    {
        if (included)
            PlayerPrefs.SetInt("Dexterity", maxAttributeLevel);
    }
}
