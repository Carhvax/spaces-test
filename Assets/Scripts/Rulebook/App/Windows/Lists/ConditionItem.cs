using UnityEngine;

public class ConditionItem : ReferenceItem
{
    [SerializeField] private Transform _content;
    [SerializeField] private ItemField _fieldPrefab;

    public void Fill(RulebookRepository repository, RuleMethod preset)
    {
        if (repository.TryGetMethod(preset.Type, out var method))
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

    public void Fill(RulebookRepository repository, MethodReference reference)
    {
        if (repository.TryGetMethod(reference.Type, out var method))
        {
            var instance = Instantiate(_fieldPrefab, _content);
            instance.Init(method.Icon, reference.Type.ToString(), "");
        }
    }
}
