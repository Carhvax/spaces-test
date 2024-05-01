using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockItem : ListItem {
    [SerializeField] private TMP_Text _counterField;

    [Space]
    [SerializeField] private Button _addConditionButton;
    [SerializeField] private Button _addActionButton;

    [Space]
    [SerializeField] private ConditionList _conditions;
    [SerializeField] private ActionList _actions;

    [Space]
    [SerializeField] private ItemField _fieldPrefab;
    [SerializeField] private ActionItem _actionPrefab;

    private RulebookRepository _repository;

    public void OnInitialize(int index, RulebookBlock block, RulebookRepository repository)
    {
        _repository = repository;

        ChangeIndex(index);

        if (block == null) return;

        if(block.Condition != null)
        {
            /*var action = Instantiate(_actionPrefab);

            action.Fill(repository, block.Condition);

            _actions.Add(action);*/
        }

        block.Actions.Each(preset =>
        {
            var action = Instantiate(_actionPrefab);

            action.Fill(_repository, preset);

            _actions.Add(action);
        });
    }

    public void ChangeIndex(int index) => _counterField.text = $"{index}";

    private void OnEnable()
    {
        _addActionButton.onClick.AddListener(OnRequestAction);
        _addConditionButton.onClick.AddListener(OnRequestCondition);
    }

    private void OnRequestCondition()
    {
        WindowsContainer.Pick<ConditionItem>(item => {

        });
    }

    private void OnRequestAction()
    {
        WindowsContainer.Pick<ActionItem>(item => {
            if(item && item.Reference)
            {
                var action = Instantiate(_actionPrefab);

                action.Fill(_repository, item.Reference);

                _actions.Add(action);

                _actions.ForceLayout();
            }
        });
    }

    private void OnDestroy()
    {
        _addActionButton.onClick.RemoveAllListeners();
        _addConditionButton.onClick.RemoveAllListeners();
    }
}
