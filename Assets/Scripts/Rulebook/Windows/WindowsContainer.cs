using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowsContainer : MonoBehaviour
{
    private readonly Stack<Window> _history = new();

    private Window[] _windows;
    private Window _current;

    private void OnValidate()
    {
        _windows = GetComponentsInChildren<Window>();
    }

    public void Back()
    {
        if (_history.Count > 0)
            Change(_history.Pop(), WindowSlideDirection.Left);
    }

    public void Change<TWindow>() where TWindow: Window
    {
        if (_current != null) _history.Push(_current);

        Change(_windows.OfType<TWindow>().FirstOrDefault(), WindowSlideDirection.Right);
    }

    private void Change(Window window, WindowSlideDirection direction)
    {
        _current?.Hide(direction);
        _current = window;
        _current?.Show(direction);
    }

}
