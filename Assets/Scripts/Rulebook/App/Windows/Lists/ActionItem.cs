using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionItem : ReferenceItem, IPointerDownHandler
{
    [SerializeField] private ItemField _fieldPrefab;
    [SerializeField] private Transform _content;
    private Action<ActionItem> _onPickItem;

    public MethodReference Reference { get; private set; }

    public void Fill(RulebookRepository repository, RuleMethod preset)
    {
        if(repository.TryGetMethod(preset.Type, out var method))
        {
            var instance = Instantiate(_fieldPrefab, _content);
            instance.Init(method.Icon, preset.Type.ToString(), "");

            method.Params.For((i, p) =>
            {
                if (repository.TryGetValue(p, out var value))
                {
                    var param = Instantiate(_fieldPrefab, _content);
                    var v = preset.Inputs[i].Value;

                    param.Init(value.Icon, value.Type.ToString(), v, true);
                }
            });
        }
        
    }

    public void OnPickItem(Action<ActionItem> pickUp)
    {
        _onPickItem = pickUp;
    }

    public void Fill(RulebookRepository repository, MethodReference reference)
    {
        Reference = reference;

        if (repository.TryGetMethod(reference.Type, out var method))
        {
            var instance = Instantiate(_fieldPrefab, _content);
            instance.Init(method.Icon, reference.Type.ToString(), "");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _onPickItem?.Invoke(this);
    }
}
