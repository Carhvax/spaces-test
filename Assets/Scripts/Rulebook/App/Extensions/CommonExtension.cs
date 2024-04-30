using System;
using System.Collections.Generic;
using System.Linq;

public static class CommonExtension
{
    public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> onItem)
    {
        var buffer = source.ToArray();

        foreach (var item in buffer)
            onItem?.Invoke(item);

        return buffer;
    }

    public static IEnumerable<T> For<T>(this IEnumerable<T> source, Action<int, T> onItem)
    {
        var buffer = source.ToArray();

        for (int i = 0; i < buffer.Length; i++)
            onItem?.Invoke(i, buffer[i]);

        return buffer;
    }
}
