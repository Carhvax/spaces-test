using Spaces.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GuidedPanel;

public class GuidedPanelsContainer : Singlton<GuidedPanelsContainer>
{
    [SerializeField] private GuidedPanel[] _panels;

    private readonly Stack<GuidedPanel> _history = new();

    private GuidedPanel _current;

    private void OnValidate() => _panels = GetComponentsInChildren<GuidedPanel>(true);

    private void Awake() => _panels.Each(p => p.gameObject.SetActive(false));

    public void Back()
    {
        if (_history.Count > 0)
            Change(_history.Pop(), GuidedDirection.Right);
    }

    public TPanel Change<TPanel>() where TPanel: GuidedPanel
    {
        if (_current != null) _history.Push(_current);

        if(_history.Count > 0 && _history.Peek() is TPanel)
            Back();
        else
            Change(_panels.OfType<TPanel>().FirstOrDefault(), GuidedDirection.Right);

        return _current as TPanel;
    }

    public TPanel From<TPanel>() where TPanel : GuidedPanel => _panels.OfType<TPanel>().FirstOrDefault();

    private void Change(GuidedPanel panel, GuidedDirection direction)
    {
        _current?.Hide(direction);
        _current = panel;
        _current?.Show(direction);
    }
}

public static class GuidedExtension
{
    public static int ToInt(this GuidedDirection direction) => direction switch
        {
            GuidedDirection.Left => -1,
            GuidedDirection.Right => 1,
            _ => 0,
        };
}