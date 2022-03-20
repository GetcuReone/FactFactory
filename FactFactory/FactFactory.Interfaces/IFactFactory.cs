using GetcuReone.FactFactory.Interfaces.Operations;
using System;
using System.Threading.Tasks;

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
        /// Collection of rules for derive facts.
        /// </summary>
        TFactRuleCollection Rules { get; }

        /// <summary>
        /// Derive the facts.
        /// </summary>
        void Derive();

        /// <summary>
        /// Asynchronously derive the facts.
        /// </summary>
        /// <returns></returns>
        ValueTask DeriveAsync();

        /// <summary>
        /// Requesting a desired fact through action.
        /// </summary>
        /// <param name="wantAction">WantAction.</param>
        /// <param name="container">Fact container.</param>
        void WantFacts(TWantAction wantAction, TFactContainer container);
    }
}
