using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ActionResponse
{

}

[CreateAssetMenu(menuName = "Repositories/ResponseActions", fileName = "ActionsRepository")]
public class ActionsRepository : ScriptableObject, IEnumerable<ActionResponse>
{
    [SerializeField] private ActionResponse[] _items;

    public IEnumerator<ActionResponse> GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}
