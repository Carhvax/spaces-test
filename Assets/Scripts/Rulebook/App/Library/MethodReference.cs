using System.Collections.Generic;
using UnityEngine;

public enum MethodType { Always, When, Move, Rotate, Hit }

[CreateAssetMenu(fileName = "RuleMethod", menuName = "Repositories/Library/MethodType")]
public class MethodReference : ScriptableObject
{
    public MethodType Type;
    public Sprite Icon;
    public List<ValueType> Params;
}
