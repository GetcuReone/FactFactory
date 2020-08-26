using System.Collections.Generic;

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
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        bool IsReadOnly { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
