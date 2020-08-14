using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface.
    /// </summary>
    /// <typeparam name="TFactBase">All facts that the fact factory works with should be inherited from this type.</typeparam>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IFactFactory<TFactBase, TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
        where TFactRuleCollection : IFactRuleCollection<TFactBase, TFactRule>
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        /// <summary>
        /// Fact container.
        /// </summary>
        TFactContainer Container { get; }

        /// <summary>
        /// Collection of rules for derive facts.
        /// </summary>
        TFactRuleCollection Rules { get; }

        /// <summary>
        /// Derive the facts.
        /// </summary>
        void Derive();

        /// <summary>
        /// Derive <typeparamref name="TWantFact"/>.
        /// </summary>
        /// <typeparam name="TWantFact">Type of desired fact.</typeparam>
        /// <returns></returns>
        TWantFact DeriveFact<TWantFact>() where TWantFact : TFactBase;

        /// <summary>
        /// Requesting a desired fact through action.
        /// </summary>
        /// <param name="wantAction"></param>
        void WantFact(TWantAction wantAction);

        /// <summary>
        /// Get <see cref="ISingleEntityOperations"/>.
        /// </summary>
        /// <returns></returns>
        ISingleEntityOperations GetSingleEntityOperations();

        /// <summary>
        /// Get <see cref="IFactTypeCache"/>.
        /// </summary>
        /// <returns></returns>
        IFactTypeCache GetFactTypeCache();
    }
}
