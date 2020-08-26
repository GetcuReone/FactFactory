using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Versioned fact factory interface.
    /// </summary>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IVersionedFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : IFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactContainer : IFactContainer
        where TFactRule : IFactRule
        where TFactRuleCollection : IFactRuleCollection<TFactRule>
        where TWantAction : IWantAction
    {
        /// <summary>
        /// Derive <typeparamref name="TFactResult"/> with version <typeparamref name="TVersion"/>.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Version info.</typeparam>
        /// <returns></returns>
        TFactResult DeriveFact<TFactResult, TVersion>()
            where TFactResult : IFact
            where TVersion : IVersionFact;
    }
}
