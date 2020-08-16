using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Single operations on entities of the FactFactory.
    /// </summary>
    public interface ISingleEntityOperations
    {
        /// <summary>
        /// Validate and return a copy of the container.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        TFactContainer ValidateAndGetContainer<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer;

        /// <summary>
        /// Validate and return a copy of the rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TFactRuleCollection"></typeparam>
        /// <param name="ruleCollection"></param>
        /// <returns></returns>
        TFactRuleCollection ValidateAndGetRules<TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>;

        /// <summary>
        /// Get comparer for <see cref="IFactRule"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IComparer<IFactRule> GetRuleComparer(IWantActionContext context);

        /// <summary>
        /// Get compatible rules.
        /// </summary>
        /// <param name="target">The purpose with which the rules must be compatible.</param>
        /// <param name="factRules">List of rules.</param>
        /// <param name="context">Context.</param>
        /// <returns>Compatible rules.</returns>
        IEnumerable<IFactRule> GetCompatibleRules(IFactWork target, IEnumerable<IFactRule> factRules, IWantActionContext context);
    }
}
