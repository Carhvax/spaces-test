using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowsContainer : MonoBehaviour
{
    private static WindowsContainer _instance;

    public static TWindow Open<TWindow>() where TWindow : Window => _instance.Change<TWindow>();
    public static void ReturnBack() => _instance.Back();

    public static void Pick<TItem>(Action<TItem> complete) where TItem : ListItem
    {
        var window = Open<PickerWindow<TItem>>();

        window.Pick((item) => {
            complete?.Invoke(item);
            ReturnBack();
        });
    }

    private readonly Stack<Window> _history = new();

    private Window[] _windows;
    private Window _current;

    public void Init()
    {
        // TODO: Should be replaces with system;
        _instance = this;

        foreach (var window in _windows) {
            window.gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {
        _windows = GetComponentsInChildren<Window>(true);
    }

    public void Back()
    {
        var window = _history.Count > 0 ? _history.Pop() : null;
        Change(window, WindowSlideDirection.RightToLeft);
    }

    public TWindow Change<TWindow>() where TWindow: Window
    {
        if (_current != null) _history.Push(_current);

        Change(_windows.OfType<TWindow>().FirstOrDefault(), WindowSlideDirection.LeftToRight);

        return _current as TWindow;
    }

    private void Change(Window window, WindowSlideDirection direction)
    {
        _current?.Hide(direction);
        _current = window;
        _current?.Show(direction);
    }

}
