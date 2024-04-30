using DG.Tweening;
using Spaces.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class RuleListPanel : GuidedPanel
{
    [Space]
    [SerializeField] private Button _addBlockButton;
    [SerializeField] private ItemList<RuleBlockItem> _blocks;

    [Space]
    [SerializeField] private ActionsRepository _actions;

    [Space]
    [SerializeField] private RuleBlockItem _blockPrefab;
    [SerializeField] private RuleEventItem _eventPrefab;
    [SerializeField] private RuleResponseItem _responsePrefab;

    private GuidedPanelsContainer Container => GuidedPanelsContainer.Instance;

    public void Init()
    {
        _actions.Each((item) => {
            var instance = Instantiate(_responsePrefab);
            instance.Init(item);
            Container.From<RuleResponsePicker>().AddItem(instance);
        });
        
    }

    protected override void OnPanelShow() => _addBlockButton.onClick.AddListener(AddBlock);

    private void AddBlock()
    {
        var block = Instantiate(_blockPrefab);

        DOTweenHelper
            .AddBlock(block, () => {
                block.OnAddEventClick(OnAddEventToBlock);
                block.OnAddResponseClick(OnAddResponseToBlock);
                block.OnRemoveBlockClick(OnRemoveBlockFromList);
            })
            .Play();

        _blocks.Add(block);
    }

    private void OnRemoveBlockFromList(RuleBlockItem block)
    {
        DOTweenHelper
            .RemoveBlockFromList(block, () => {
                block.Dispose();
                _blocks.Remove(block);
            })
            .Play();
    }

    private void OnAddResponseToBlock(RuleBlockItem block)
    {
        Container.Change<RuleResponsePicker>().OnSelect((item) => {

            if (item != null)
            {
                // TODO: Add item to block
            }

            Container.Back();
        });
    }

    private void OnAddEventToBlock(RuleBlockItem block)
    {
        Container.Change<RuleEventPicker>().OnSelect((item) => {

            if (item != null)
            {
                // TODO: Add item to block
            }

            Container.Back();
        });
    }

    protected override void OnPanelHide() => _addBlockButton.onClick.RemoveAllListeners();
}
