using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListItem : MonoBehaviour { }

public abstract class ItemList<T> : MonoBehaviour, IEnumerable<T> where T: ListItem
{
    [SerializeField] private uint _skipItems;

    private readonly HashSet<T> _items = new();

    protected IEnumerable<T> Items => _items;

    public void Add(T item)
    {
        _items.Add(item);

        item.transform.SetParent(transform);

        if(_skipItems != 0)
            item.transform.SetSiblingIndex(transform.childCount - (int)_skipItems - 1);

        OnListWasChanged();
    }

    protected virtual void OnListWasChanged() { }

    public void Remove(T item)
    {
        _items.Remove(item);

        Destroy(item.gameObject);

        OnListWasChanged();
    }

    public void Clear() => _items.Each(Remove);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}
