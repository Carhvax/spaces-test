using System;
using UnityEngine;
using UnityEngine.UI;

public class RuleEventPicker : GuidedPanel
{
    [SerializeField] private Button _backButton;

    public void OnSelect(Action<object> onSelect)
    {
        _backButton.onClick.AddListener(() => onSelect?.Invoke(null));
    }

    protected override void OnPanelHide()
    {
        _backButton.onClick.RemoveAllListeners();
    }
}