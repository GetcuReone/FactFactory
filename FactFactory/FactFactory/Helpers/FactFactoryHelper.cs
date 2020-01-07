using System.Collections.Generic;
using System.Linq;

namespace FactFactory.Helpers
{
    internal static class FactFactoryHelper
    {
        internal static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> items)
        {
            return items == null || !items.Any();
        }
    }
}
