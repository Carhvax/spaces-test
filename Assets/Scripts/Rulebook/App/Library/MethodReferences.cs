using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MethodReferences", menuName = "Repositories/Library/MethodReferences")]
public class MethodReferences : ScriptableObject
{
    [SerializeField] private MethodReference[] _methods;

    public bool TryGetMethod(MethodType type, out MethodReference method)
    {
        method = _methods.FirstOrDefault(m => m.Type == type);

        return method != null;
    }
}