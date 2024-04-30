using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ValueReferences", menuName = "Repositories/Library/ValueReferences")]
public class ValueReferences : ScriptableObject, IEnumerable<ValueReference>
{
    [SerializeField] private ValueReference[] _values;

    public bool TryGetValue(ValueType type, out ValueReference value)
    {
        value = _values.FirstOrDefault(m => m.Type == type);

        return value != null;
    }

    public IEnumerator<ValueReference> GetEnumerator() => _values.ToList().GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

}
