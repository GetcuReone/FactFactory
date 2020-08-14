using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
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
        /// Get comparer for <see cref="IFactWork"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="container">Container within which the sorting will take place.</param>
        /// <param name="wantAction">Action within which the sorting will take place.</param>
        /// <returns></returns>
        IComparer<TFactWork> GetComparer<TFactWork, TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
