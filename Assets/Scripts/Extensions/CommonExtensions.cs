using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        public static bool IsOverlaped(this RectTransform a, RectTransform b)
        {
            var rect1 = new Rect(a.localPosition.x, a.localPosition.y, a.rect.width, a.rect.height);
            var rect2 = new Rect(b.localPosition.x, b.localPosition.y, b.rect.width, b.rect.height);

            return rect1.Overlaps(rect2);
        }
    }
}


