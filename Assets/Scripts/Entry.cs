using UnityEngine;

public class Entry : Singlton<Entry>
{
    [SerializeField] private Window _startupWindow;
    [SerializeField] private DragTarget _drag;

    private void Start()
    {
        _startupWindow.Show();
    }

    public RectTransform Clone(DragHandler handler)
    {
        _drag.gameObject.SetActive(true);

        return _drag.GetComponent<RectTransform>();
    }

    public void DisposeClone(DragHandler handler)
    {
        _drag.gameObject.SetActive(false);
    }
}
