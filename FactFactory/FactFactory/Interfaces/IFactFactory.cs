using ComboPatterns.Interfaces;
using System;
using System.Collections.Generic;

namespace FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface
    /// </summary>
    public interface IFactFactory<TFactContainer, TFactRule, TFactRuleCollection> : IAbstractFactory
        where TFactContainer : IFactContainer
        where TFactRule: IFactRule
        where TFactRuleCollection : IList<TFactRule>
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
        /// Derive a fact from the rules and return it
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        TFact DeriveAndReturn<TFact>() where TFact : IFact;

        /// <summary>
        /// Wish to derive a fact
        /// </summary>
        /// <typeparam name="TFact">type fact</typeparam>
        /// <param name="wantFactAction">action to be taken after the fact is derived from the rule</param>
        void WantFact<TFact>(Action<TFact> wantFactAction) where TFact: IFact;
    }
}
