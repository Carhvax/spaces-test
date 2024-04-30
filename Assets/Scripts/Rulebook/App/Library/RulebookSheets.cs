using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RulebookSheets", menuName = "Repositories/Sheets/RulebookSheets")]
public class RulebookSheets : ScriptableObject, IEnumerable<RulebookBlock>
{
    public List<RulebookBlock> Blocks;

    public IEnumerator<RulebookBlock> GetEnumerator() => Blocks.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Blocks.GetEnumerator();

    public void Reset() => Blocks = new List<RulebookBlock>();

    public void Add(RulebookBlock block) => Blocks.Add(block);
}

[Serializable]
public class RulebookBlock
{
    public RuleMethod Condition;
    public List<RuleMethod> Actions;
}

[Serializable]
public class RuleMethod
{
    public MethodType Type;
    public List<InputValue> Inputs;
}

[Serializable]
public class InputValue
{
    public ValueType Type;
    public string Value;
}
