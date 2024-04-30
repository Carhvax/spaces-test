using Spaces.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class DragTarget : MonoBehaviour
{
    [SerializeField] private Image _dragPlace;
    [SerializeField] private RectTransform _placeRect;

    private RectTransform _rect;

    public bool IsOverlapped => _placeRect.IsOverlaped(_rect);

    private void Awake() => _rect = GetComponent<RectTransform>();

    private void LateUpdate() => _dragPlace.color = IsOverlapped ? Color.red : Color.white;

    private void OnEnable() => _dragPlace.color = Color.white;

    private void OnDisable() => _dragPlace.color = Color.white;
}
