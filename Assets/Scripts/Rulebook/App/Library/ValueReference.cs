using UnityEngine;

public enum ValueType { Object, Position, Direction, Speed, Force, Angle, Value, Tap }

[CreateAssetMenu(fileName = "ValueReference", menuName = "Repositories/Library/ValueReference")]
public class ValueReference : ScriptableObject
{
    public ValueType Type;
    public Sprite Icon;
}