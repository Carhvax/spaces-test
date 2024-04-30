using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum WindowSlideDirection {  None, RightToLeft, LeftToRight }

public abstract class Window : MonoBehaviour
{
    [SerializeField] private float _slidingTime = .25f;

    private float _slidingDistance = 500f;
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _slidingDistance = Screen.width;
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
        var dir = direction == WindowSlideDirection.RightToLeft? -1: direction == WindowSlideDirection.LeftToRight? 1: 0;

        var startPosition = hide? 0: dir * _slidingDistance * -1;
        var endPosition = !hide? 0: dir * _slidingDistance;

        DOTween
            .Sequence()
            .Append(_rect.DOAnchorPosX(startPosition, 0))
            .Append(_rect.DOAnchorPosX(endPosition, _slidingTime))
            .OnComplete(() => {
                complete?.Invoke();
            })
            .SetLink(gameObject)
            .Play();
    }
}

public abstract class PickerWindow<TItem> : Window where TItem: class
{
    [SerializeField] private Button _backButton;

    private Action<TItem> _completeItem;

    public void Pick(Action<TItem> complete)
    {
        _completeItem = complete;

        _backButton.onClick.AddListener(() => _completeItem?.Invoke(null));
    }

    protected void PickUp(TItem item)
    {
        _completeItem?.Invoke(item);
        _backButton.onClick.RemoveAllListeners();
    }
}
