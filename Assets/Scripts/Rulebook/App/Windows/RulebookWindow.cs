using UnityEngine;

public class RulebookWindow : Window
{
    [SerializeField] private BlockList _blocks;
    [SerializeField] private RulebookSheets _rulebook;
    [SerializeField] private RulebookRepository _repository;

    [Space]
    [SerializeField] private BlockItem _blockPrefab;

    protected override void OnWindowShow()
    {
        // TODO: Read repository;
        _rulebook.For((i, rule) => {
            var block = Instantiate(_blockPrefab);

            block.OnInitialize(i, rule, _repository);

            _blocks.Add(block);
        });
    }

    protected override void OnWindowHide()
    {

    }

}
