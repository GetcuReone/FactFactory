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
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="requests">Requests.</param>
        void DeriveWantAction<TFactRuleCollection>(List<DeriveWantActionRequest<TFactRuleCollection>> requests)
            where TFactRuleCollection : IFactRuleCollection;

        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <param name="requests">Requests.</param>
        ValueTask DeriveWantActionAsync<TFactRuleCollection>(List<DeriveWantActionRequest<TFactRuleCollection>> requests)
            where TFactRuleCollection : IFactRuleCollection;
    }
}
