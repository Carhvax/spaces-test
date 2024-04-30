using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class GuidedPanel : MonoBehaviour
{
    [SerializeField] private float _slidingDistance = 1000f;
    [SerializeField] private float _slidingTime = .25f;

    [SerializeField] private CanvasGroup _group;

    private void OnValidate()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void Show(GuidedDirection direction)
    {
        gameObject.SetActive(true);

        Move(direction.ToInt(), false, OnPanelShow);
    }

    protected virtual void OnPanelShow() { }

    public void Hide(GuidedDirection direction)
    {
        Move(direction.ToInt(), true, () => {
            gameObject.SetActive(false);
            OnPanelHide();
        });
    }

    protected virtual void OnPanelHide() { }

    private void Move(int direction, bool fading, Action complete = null)
    {
        _group.alpha = 1;

        var fade = fading ? .5f : 1;
        var rect = transform.GetComponent<RectTransform>();
        var startPosition = fading ? 0 : direction * _slidingDistance * .5f;
        var endPosition = fading ? direction * _slidingDistance * .5f: 0;

        DOTween
            .Sequence()
            .Append(rect.DOAnchorPosX(startPosition, 0))
            .Append(rect.DOAnchorPosX(endPosition, _slidingTime))
            .Join(_group.DOFade(fade, _slidingTime))
            .OnComplete(() => complete?.Invoke())
            .SetLink(gameObject)
            .Play();
    }

    public enum GuidedDirection { None, Left, Right }
}
