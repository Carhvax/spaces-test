using UnityEngine;

[CreateAssetMenu(fileName = "ReferenceRepository", menuName = "Repositories/ReferenceRepository")]
public class RulebookRepository : ScriptableObject
{
    [SerializeField] private ValueReferences _values;
    [SerializeField] private MethodReferences _methods;

    public bool TryGetMethod(MethodType type, out MethodReference method) => _methods.TryGetMethod(type, out method);

    public bool TryGetValue(ValueType type, out ValueReference value) => _values.TryGetValue(type, out value);
}


