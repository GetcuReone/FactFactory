using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Engine for calculating facts
    /// </summary>
    public interface IFactEngine
    {
        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <typeparam name="TFactRule">Type of rules used.</typeparam>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="requests">Requests.</param>
        void DeriveWantAction<TFactRule, TFactRuleCollection>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>;

        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <typeparam name="TFactRule">Type of rules used.</typeparam>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="requests">Requests.</param>
        ValueTask DeriveWantActionAsync<TFactRule, TFactRuleCollection>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>;
    }
}
