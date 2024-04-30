using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MethodReferences", menuName = "Repositories/Library/MethodReferences")]
public class MethodReferences : ScriptableObject, IEnumerable<MethodReference>
{
    [SerializeField] private MethodReference[] _methods;

    public bool TryGetMethod(MethodType type, out MethodReference method)
    {
        method = _methods.FirstOrDefault(m => m.Type == type);

        return method != null;
    }

    public IEnumerator<MethodReference> GetEnumerator() => _methods.ToList().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _methods.GetEnumerator();
}