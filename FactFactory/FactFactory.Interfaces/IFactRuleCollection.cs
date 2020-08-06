using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Collection of rules.
    /// </summary>
    /// <typeparam name="TFactBase">Base fact type.</typeparam>
    /// <typeparam name="TFactRule">Rule type.</typeparam>
    public interface IFactRuleCollection<TFactBase, TFactRule> : IList<TFactRule>, ICopy<IFactRuleCollection<TFactBase, TFactRule>>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="IFactRuleCollection{TFactBase, TFactRule}"/> is read-only.
        /// </summary>
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        bool IsReadOnly { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
