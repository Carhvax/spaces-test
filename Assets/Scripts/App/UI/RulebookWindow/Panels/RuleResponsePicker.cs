using System;
using UnityEngine;
using UnityEngine.UI;

public class RuleResponsePicker : GuidedPanel
{
    [SerializeField] private Button _backButton;
    [SerializeField] private ResponsesList _content;

    public void OnSelect(Action<object> onSelect)
    {
        _backButton.onClick.AddListener(() => onSelect?.Invoke(null));
    }

    public void AddItem(RuleResponseItem instance) 
    {
        _content.Add(instance);
    }

    protected override void OnPanelShow()
    {
        
    }

    protected override void OnPanelHide()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    
}
