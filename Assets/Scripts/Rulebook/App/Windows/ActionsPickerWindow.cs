using UnityEngine;

public class ActionsPickerWindow : PickerWindow<ActionItem> {
    [SerializeField] private RulebookRepository _repository;
    [SerializeField] private ActionItem _actionPrefab;
    [SerializeField] private ActionList _actions;

    protected override void OnWindowShow()
    {
        _repository.Methods.Each(m =>
        {
            var instance = Instantiate(_actionPrefab);
            instance.Fill(_repository, m);
            instance.OnPickItem(PickUp);
            _actions.Add(instance);
        });
    }

    protected override void OnWindowHide()
    {
        _actions.Clear();
    }
}
