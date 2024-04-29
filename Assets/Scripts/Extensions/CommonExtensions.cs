using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaces.Extensions
{
    public static class CommonExtensions
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> onItem)
        {
            var cached = source.ToArray();
            foreach (var item in cached)
                onItem?.Invoke(item);

            return cached;
        }
    }
}


