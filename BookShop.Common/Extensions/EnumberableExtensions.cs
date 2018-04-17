using System.Collections.Generic;

namespace BookShop.Common.Extensions
{
    public static class EnumberableExtensions
    {
        public static ISet<T> ToHashSet<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);
    }
}
