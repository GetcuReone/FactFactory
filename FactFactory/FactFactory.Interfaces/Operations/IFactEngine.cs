using GetcuReone.FactFactory.Interfaces.Context;
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
        /// <typeparam name="TWantAction">Type wantAction</typeparam>
        /// <typeparam name="TFactContainer">Type container</typeparam>
        /// <param name="requests">Requests.</param>
        void DeriveWantAction<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;

        /// <summary>
        /// Build a trees and calculate facts for <paramref name="requests"/>.
        /// </summary>
        /// <typeparam name="TFactRule">Type of rules used.</typeparam>
        /// <typeparam name="TFactRuleCollection">Rule collection type.</typeparam>
        /// <typeparam name="TWantAction">Type wantAction</typeparam>
        /// <typeparam name="TFactContainer">Type container</typeparam>
        /// <param name="requests">Requests.</param>
        ValueTask DeriveWantActionAsync<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>(List<DeriveWantActionRequest<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>> requests)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
