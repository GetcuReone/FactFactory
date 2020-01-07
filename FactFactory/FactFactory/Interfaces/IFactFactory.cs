using ComboPatterns.Interfaces;
using System;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface
    /// </summary>
    public interface IFactFactory<TFactRule> : IAbstractFactory
        where TFactRule: IFactRule
    {
        /// <summary>
        /// Fact container
        /// </summary>
        IFactContainer FactContainer { get; }

        /// <summary>
        /// Collection of rules for derive facts
        /// </summary>
        IList<TFactRule> FactRuleCollection { get; }

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
