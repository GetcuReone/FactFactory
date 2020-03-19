using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Versioned fact factory interface.
    /// </summary>
    /// <typeparam name="TFact">All facts that the fact factory works with should be inherited from this type.</typeparam>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IVersionedFactFactory<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction> : IFactFactory<TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction>
        where TFact : IVersionFact
        where TFactContainer : IFactContainer<TFact>
        where TFactRule : IVersionedFactRule<TFact>
        where TFactRuleCollection : IList<TFactRule>
        where TWantAction : IWantAction<TFact>, IFactTypeVersionInfo
    {
        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version <typeparamref name="TVersion"/>.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Version info.</typeparam>
        /// <returns></returns>
        TFactResult DeriveFact<TFactResult, TVersion>()
            where TFactResult : TFact
            where TVersion : TFact, IVersionFact;
    }
}
