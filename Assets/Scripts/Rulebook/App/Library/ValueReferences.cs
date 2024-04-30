using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ValueReferences", menuName = "Repositories/Library/ValueReferences")]
public class ValueReferences : ScriptableObject
{
    [SerializeField] private ValueReference[] _values;

    public bool TryGetValue(ValueType type, out ValueReference value)
    {
        value = _values.FirstOrDefault(m => m.Type == type);

        return value != null;
    }

}
