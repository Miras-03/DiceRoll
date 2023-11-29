using DiceSpace.StartObserver;
using DG.Tweening;
using UnityEngine;
using DiceSpace;

public sealed class FollowDice : MonoBehaviour, IRollStartObserver
{
    [Header("Transforms")]
    [SerializeField] private RectTransform target;
    [SerializeField] private RectTransform pathTransform;

    private DicePath dicePath;

    private const int followSpeed = 6;

    private void Awake()
    {
        dicePath = DicePath.Instance;
        
    }

    private void Start()
    {
        dicePath.PathTransform = pathTransform;
        dicePath.SetEdgePoints();
    }

    public void OnDiceRollStart() => DelayAndFollow();

    private void DelayAndFollow()
    {
        transform.
            DOPath(dicePath.DiceEdges, followSpeed, PathType.CatmullRom).
            SetSpeedBased().
            SetEase(Ease.OutSine).
            SetLookAt(target);
    }
}