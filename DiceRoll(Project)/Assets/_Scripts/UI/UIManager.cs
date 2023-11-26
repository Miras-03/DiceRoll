using DiceOption;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IDiceCompleteObserver
{
    [SerializeField] private Button rollButton;

    [Space(20)]
    [Header("UI Texts")]
    [SerializeField] private TextMeshProUGUI resultOfRoll;
    [SerializeField] private TextMeshProUGUI clickDiceText;

    public void ShowResult(string result) => resultOfRoll.text = result;

    public void SetTextMeshPro(bool target) => clickDiceText.enabled = target;

    public void SetButton(bool target) => rollButton.enabled = target;

    public void OnDiceRollCompleted()
    {
        SetTextMeshPro(true);
        SetButton(true);
    }
}
