using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListItem : MonoBehaviour { }

public abstract class ItemList<T> : MonoBehaviour, IEnumerable<T> where T: ListItem
{
    [SerializeField] private uint _skipItems;

    private readonly HashSet<T> _items = new();
    private Action _nextTask;

    protected IEnumerable<T> Items => _items;

    public void Add(T item)
    {
        _items.Add(item);

        item.transform.SetParent(transform);

        if(_skipItems != 0)
            item.transform.SetSiblingIndex(transform.childCount - (int)_skipItems - 1);

        OnListWasChanged();
    }

    public void ForceLayout() {
        Canvas.ForceUpdateCanvases();

        FindObjectsOfType<VerticalLayoutGroup>().Each(group => {
            group.enabled = false;
            
            StartCoroutine(UpdateTask(() => {
                group.enabled = true;
            }));
        });
    }

    private IEnumerator UpdateTask(Action onTime)
    {
        yield return new WaitForEndOfFrame();

        onTime?.Invoke();
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
