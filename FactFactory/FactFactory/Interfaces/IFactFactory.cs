using ComboPatterns.Interfaces;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface
    /// </summary>
    public interface IFactFactory<TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IAbstractFactory
        where TFactContainer : class, IFactContainer
        where TFactRule : class, IFactRule
        where TFactRuleCollection : class, IList<TFactRule>
        where TWantAction : class, IWantAction
    {
        /// <summary>
        /// Fact container
        /// </summary>
        TFactContainer Container { get; }

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        TFactRuleCollection Rules { get; }

        /// <summary>
        /// Derive the facts
        /// </summary>
        void Derive();

        /// <summary>
        /// Requesting a desired fact through action
        /// </summary>
        /// <param name="wantAction"></param>
        void WantFact(TWantAction wantAction);
    }
}
