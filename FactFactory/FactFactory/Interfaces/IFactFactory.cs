using GetcuReone.ComboPatterns.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface.
    /// </summary>
    /// <typeparam name="TFact">All facts that the fact factory works with should be inherited from this type.</typeparam>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IFactFactory<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IAbstractFactory
        where TFact : IFact
        where TFactContainer : IFactContainer<TFact>
        where TFactRule : IFactRule<TFact>
        where TFactRuleCollection : IList<TFactRule>
        where TWantAction : IWantAction<TFact>
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
        /// Derive <typeparamref name="TWantFact"/>.
        /// </summary>
        /// <typeparam name="TWantFact">Type of desired fact.</typeparam>
        /// <returns></returns>
        TWantFact DeriveFact<TWantFact>() where TWantFact : TFact;

        /// <summary>
        /// Requesting a desired fact through action
        /// </summary>
        /// <param name="wantAction"></param>
        void WantFact(TWantAction wantAction);
    }
}
