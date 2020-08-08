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
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        TFactContainer ValidateAndGetContainer<TFactBase, TFactContainer>(TFactContainer container)
            where TFactBase : IFact
            where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// Validate and return a copy of the rules.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TFactRuleCollection"></typeparam>
        /// <param name="ruleCollection"></param>
        /// <returns></returns>
        TFactRuleCollection ValidateAndGetRules<TFactBase, TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactBase : IFact
            where TFactRule : IFactRule<TFactBase>
            where TFactRuleCollection : IFactRuleCollection<TFactBase, TFactRule>;

        /// <summary>
        /// Get comparer fro <see cref="IFactWork{TFactBase}"/>.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactWork"></typeparam>
        /// <returns></returns>
        IComparer<TFactWork> GetComparer<TFactBase, TFactWork>()
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>;
    }
}
