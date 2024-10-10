using System;
using System.Collections.Generic;

#pragma warning disable CS0108
namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Collection of rules.
    /// </summary>
    public interface IFactRuleCollection : IList<IFactRule>, ICopy<IFactRuleCollection>
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactRuleCollection"/> is read-only.
        /// </summary>
        bool IsReadOnly { get; set; }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="IFactRuleCollection"/>
        /// </summary>
        /// <param name="rules">The collection whose elements should be added to the end of the  <see cref="IFactRuleCollection"/>. 
        /// The collection itself cannot be null, but it can contain elements that are null,
        /// if type T is a reference type.</param>
        void AddRange(IEnumerable<IFactRule> rules);

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An <see cref="IFactRuleCollection"/> that contains elements from the input
        /// sequence that satisfy the condition.
        /// </returns>
        IFactRuleCollection FindAll(Func<IFactRule, bool> predicate);

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// An <see cref="IFactRuleCollection"/> whose elements are sorted in
        /// descending orderaccording to a key.
        /// </returns>
        IFactRuleCollection SortByDescending<TKey>(Func<IFactRule, TKey> keySelector, IComparer<TKey> comparer);
    }
}
