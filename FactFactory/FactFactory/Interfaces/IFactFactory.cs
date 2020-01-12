using ComboPatterns.Interfaces;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface
    /// </summary>
    public interface IFactFactory<TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IAbstractFactory
        where TFactContainer : IFactContainer
        where TFactRule: IFactRule
        where TFactRuleCollection : IList<TFactRule>
        where TWantAction : IWantAction
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
