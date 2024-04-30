using UnityEngine;

public class ConditionsPickerWindow : PickerWindow<ConditionItem> {
    [SerializeField] private RulebookRepository _repository;
    [SerializeField] private ConditionItem _actionPrefab;
    [SerializeField] private ConditionList _conditions;

    protected override void OnWindowShow()
    {
        _repository.Methods.Each(m =>
        {
            var instance = Instantiate(_actionPrefab);
            instance.Fill(_repository, m);
            _conditions.Add(instance);
        });
    }

    protected override void OnWindowHide()
    {
        _conditions.Clear();
    }
}
