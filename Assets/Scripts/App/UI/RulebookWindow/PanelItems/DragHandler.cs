using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private CanvasGroup _group;
    private RectTransform _clone;

    private Entry Container => Entry.Instance;

    public Vector2 Size => GetComponent<RectTransform>().sizeDelta;

    private void OnValidate()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _group.alpha = 0;

        _clone = Container.Clone(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_clone) return;

        _clone.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _group.alpha = 1;
        Container.DisposeClone(this);
    }
}
