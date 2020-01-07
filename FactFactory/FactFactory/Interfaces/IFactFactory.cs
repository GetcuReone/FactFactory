using ComboPatterns.Interfaces;
using System;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface
    /// </summary>
    public interface IFactFactory<TFactRule, TFactRuleCollection> : IAbstractFactory
        where TFactRule: IFactRule
        where TFactRuleCollection : IList<TFactRule>
    {
        /// <summary>
        /// Fact container
        /// </summary>
        IFactContainer FactContainer { get; }

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        TFactRuleCollection FactRuleCollection { get; }

        /// <summary>
        /// Derive the facts
        /// </summary>
        void Derive();

        /// <summary>
        /// Wish to derive a fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        /// <param name="wantFactAction"></param>
        void WantFact<TFact>(Action<TFact> wantFactAction) where TFact: IFact;
    }
}
