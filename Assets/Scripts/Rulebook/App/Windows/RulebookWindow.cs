using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RulebookWindow : Window
{
    [SerializeField] private BlockList _blocks;
    [SerializeField] private RulebookSheets _rulebook;
    [SerializeField] private RulebookRepository _repository;
    [SerializeField] private Button _addBlockButton;

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

        _addBlockButton.onClick.AddListener(() => {
            var block = Instantiate(_blockPrefab);

            block.OnInitialize(_rulebook.Count(), null, _repository);

            _blocks.Add(block);
        });
    }

    protected override void OnWindowHide()
    {

    }

}
