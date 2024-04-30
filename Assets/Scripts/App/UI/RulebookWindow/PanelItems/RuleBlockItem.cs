using System;
using UnityEngine;
using UnityEngine.UI;

public class RuleBlockItem : ListItem
{
    [SerializeField] private Button _addEventButton;
    [SerializeField] private Button _addResponseButton;
    [SerializeField] private Button _removeBlockButton;

    [Space]
    [SerializeField] private ItemList<RuleEventItem> _events;
    [SerializeField] private ItemList<RuleResponseItem> _responses;

    public void AddEvent(RuleEventItem item) => _events.Add(item);

    public void AddResponse(RuleResponseItem item) => _responses.Add(item);

    public void OnAddEventClick(Action<RuleBlockItem> onClick) => _addEventButton.onClick.AddListener(() => onClick?.Invoke(this));

    public void OnAddResponseClick(Action<RuleBlockItem> onClick) => _addResponseButton.onClick.AddListener(() => onClick?.Invoke(this));

    public void OnRemoveBlockClick(Action<RuleBlockItem> onClick) => _removeBlockButton.onClick.AddListener(() => onClick?.Invoke(this));

    public void Dispose()
    {
        _addEventButton.onClick.RemoveAllListeners();
        _addResponseButton.onClick.RemoveAllListeners();
        _removeBlockButton.onClick.RemoveAllListeners();

        _events.Clear();
        _responses.Clear();
    }
}
