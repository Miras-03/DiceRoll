using DiceSpace.StartObserver;
using DG.Tweening;
using UnityEngine;
using DiceSpace;
using System.Collections;

public sealed class FollowDice : MonoBehaviour, IRollStartObserver
{
    [SerializeField] private RectTransform target;
    [SerializeField] private RectTransform pathParent;
    private DicePath dicePath;

    private const float rollDuration = 3;

    private void Awake() => dicePath = DicePath.Instance;

    private void Start()
    {
        dicePath.SetParent(pathParent);
        dicePath.SetEdgePoints();
    }

    public void OnDiceRollStart() => StartCoroutine(DelayAndFollow());

    private IEnumerator DelayAndFollow()
    {
        yield return new WaitForSeconds(0.1f);

        transform.
            DOPath(dicePath.DiceEdges, rollDuration, PathType.CatmullRom).
            SetEase(Ease.OutSine).
            SetLookAt(target);
    }
}