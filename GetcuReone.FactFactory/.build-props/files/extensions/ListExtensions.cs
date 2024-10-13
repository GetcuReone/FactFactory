using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class ListExtensions
{
    /// <summary>
    /// True - <paramref name="items"/> is null or empty.
    /// </summary>
    /// <typeparam name="TItem">Type items.</typeparam>
    /// <param name="items">Collection.</param>
    /// <returns><paramref name="items"/> is empty or null?</returns>
    internal static bool IsNullOrEmpty<TItem>([NotNullWhen(false)][MaybeNull] this List<TItem> items)
    {
        return items == null || items.Count == 0;
    }
}
