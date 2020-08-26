using GetcuReone.FactFactory.Interfaces.Operations;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact factory interface.
    /// </summary>
    /// <typeparam name="TFactContainer">Type fact container.</typeparam>
    /// <typeparam name="TFactRule">Type fact rule.</typeparam>
    /// <typeparam name="TFactRuleCollection">Type set rule.</typeparam>
    /// <typeparam name="TWantAction">Type 'want action'.</typeparam>
    public interface IFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TFactRuleCollection : IFactRuleCollection<TFactRule>
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
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
        /// Derive <typeparamref name="TFactResult"/>.
        /// </summary>
        /// <typeparam name="TFactResult">Type of desired fact.</typeparam>
        /// <returns></returns>
        TFactResult DeriveFact<TFactResult>() where TFactResult : IFact;

        /// <summary>
        /// Requesting a desired fact through action.
        /// </summary>
        /// <param name="wantAction"></param>
        void WantFact(TWantAction wantAction);

        /// <summary>
        /// Get <see cref="ITreeBuildingOperations"/>.
        /// </summary>
        /// <returns></returns>
        ITreeBuildingOperations GetTreeBuildingOperations();

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
