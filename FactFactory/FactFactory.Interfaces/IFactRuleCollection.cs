using System;
using System.Collections.Generic;

#pragma warning disable CS0108
namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Collection of rules.
    /// </summary>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public interface IFactRuleCollection<TFactRule> : IList<TFactRule>, ICopy<IFactRuleCollection<TFactRule>>
        where TFactRule : IFactRule
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactRuleCollection{TFactRule}"/> is read-only.
        /// </summary>
        bool IsReadOnly { get; set; }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An <see cref="IFactRuleCollection{TFactRule}"/> that contains elements from the input
        /// sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is null.</exception>
        IFactRuleCollection<TFactRule> FindAll(Func<TFactRule, bool> predicate);

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// An <see cref="IFactRuleCollection{TFactRule}"/> whose elements are sorted in
        /// descending orderaccording to a key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is null.</exception>
        IFactRuleCollection<TFactRule> SortByDescending<TKey>(Func<TFactRule, TKey> keySelector, IComparer<TKey> comparer);
    }
}
