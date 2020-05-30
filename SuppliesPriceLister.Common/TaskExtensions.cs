using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Common
{
    public static class TaskExtensions
    {
        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            return Task.WhenAll(tasks.ToList());
        }

    }
}
