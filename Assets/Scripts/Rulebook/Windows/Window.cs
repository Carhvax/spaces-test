using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;

public enum WindowSlideDirection {  None, Left, Right }


public abstract class Window : MonoBehaviour
{
    [SerializeField] private float _slidingDistance = 500f;
    [SerializeField] private float _slidingTime = .25f;

    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void Show(WindowSlideDirection direction = WindowSlideDirection.None)
    {
        gameObject.SetActive(true);

        Slide(direction, false, () => {
            OnWindowShow();
        });
    }

    protected virtual void OnWindowShow() { }

    public void Hide(WindowSlideDirection direction = WindowSlideDirection.None)
    {
        Slide(direction, true, () => {
            OnWindowHide();

            gameObject.SetActive(false);
        });
        
    }

    protected virtual void OnWindowHide() { }

    protected void Slide(WindowSlideDirection direction, bool hide, Action complete) 
    {
        var dir = direction == WindowSlideDirection.Left? -1: direction == WindowSlideDirection.Right? 1: 0;

        var startPosition = hide? 0: dir * _slidingDistance * -.5f;
        var endPosition = !hide? 0: dir * _slidingDistance * .5f;

        DOTween
            .Sequence()
            .Append(_rect.DOAnchorPosX(startPosition, 0))
            .Append(_rect.DOAnchorPosX(endPosition, _slidingDistance))
            .OnComplete(() => {
                complete?.Invoke();
            })
            .Play();
    }
}
