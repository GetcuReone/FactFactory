using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Versioned fact factory interface.
    /// </summary>
    /// <typeparam name="TFactBase">All facts that the fact factory works with should be inherited from this type.</typeparam>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IVersionedFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IFactFactory<TFactBase, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFactBase : IVersionedFact
        where TFactContainer : IFactContainer<TFactBase>
        where TFactRule : IVersionedFactRule<TFactBase>
        where TFactRuleCollection : IFactRuleCollection<TFactBase, TFactRule>
        where TWantAction : IWantAction<TFactBase>, IFactTypeVersionInfo
    {
        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version <typeparamref name="TVersion"/>.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Version info.</typeparam>
        /// <returns></returns>
        TFactResult DeriveFact<TFactResult, TVersion>()
            where TFactResult : TFactBase
            where TVersion : IVersionFact;
    }
}
