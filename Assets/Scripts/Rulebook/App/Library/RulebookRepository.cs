using UnityEngine;

[CreateAssetMenu(fileName = "ReferenceRepository", menuName = "Repositories/ReferenceRepository")]
public class RulebookRepository : ScriptableObject
{
    public ValueReferences Values;
    public MethodReferences Methods;

    public bool TryGetMethod(MethodType type, out MethodReference method) => Methods.TryGetMethod(type, out method);

    public bool TryGetValue(ValueType type, out ValueReference value) => Values.TryGetValue(type, out value);
}


