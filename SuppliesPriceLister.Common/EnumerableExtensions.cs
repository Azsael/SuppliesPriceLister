using System;
using System.Collections.Generic;

namespace SuppliesPriceLister.Common
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static string JoinString(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}