using System;
using UnityEngine;

public class SubscriptionDispose : IDisposable
{
    private Action _onDispose;

    public SubscriptionDispose(Action onDispose)
    {
        _onDispose = onDispose;
    }

    public void Dispose()
    {
        _onDispose?.Invoke();
    }
}

public abstract class Singlton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType <T>();

            return _instance;
        }
    }
}