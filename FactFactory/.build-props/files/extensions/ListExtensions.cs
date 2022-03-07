using System.Collections.Generic;
using System.Collections.ObjectModel;

internal static class ListExtensions
{
    /// <summary>
    /// True - <paramref name="items"/> is null or empty
    /// </summary>
    /// <typeparam name="TItem">Type items.</typeparam>
    /// <param name="items">Collection.</param>
    /// <returns><paramref name="items"/> is empty or null?</returns>
    internal static bool IsNullOrEmpty<TItem>(this List<TItem> items)
    {
        return items == null || items.Count == 0;
    }

    /// <summary>
    /// Convert list to <see cref="ReadOnlyCollection{TItem}"/>
    /// </summary>
    /// <typeparam name="TItem">Type item.</typeparam>
    /// <param name="items">Coollection.</param>
    /// <returns>Read-only collection.</returns>
    internal static ReadOnlyCollection<TItem> ToReadOnlyCollection<TItem>(this IList<TItem> items)
    {
        return new ReadOnlyCollection<TItem>(items);
    }
}
