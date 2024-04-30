using Spaces.Extensions;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemList<T>: MonoBehaviour where T: ListItem
{
    [SerializeField] private Transform _content;
    [SerializeField] private bool _inserting;

    public readonly HashSet<T> _items = new();

    public void Add(T item) {
        item.transform.SetParent(_content);

        if (_inserting)
            item.transform.SetSiblingIndex(_content.childCount - 2);
            
        _items.Add(item);
    }

    public void Remove(T item) {
        _items.Remove(item);
        Destroy(item.gameObject);
    }

    public void Clear() => _items.Each(Remove);
}
