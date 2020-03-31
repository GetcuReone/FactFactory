using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base collection for <typeparamref name="TFactRule"/>.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    /// <typeparam name="TFactRule"></typeparam>
    public abstract class VersionedFactRuleCollectionBase<TFactBase, TFactRule> : FactRuleCollectionBase<TFactBase, TFactRule>
        where TFactBase : class, IVersionedFact
        where TFactRule : IVersionedFactRule<TFactBase>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected VersionedFactRuleCollectionBase() : base(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        protected VersionedFactRuleCollectionBase(IEnumerable<TFactRule> factRules) : base(factRules, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        protected VersionedFactRuleCollectionBase(IEnumerable<TFactRule> factRules, bool isReadOnly) : base(factRules, isReadOnly)
        {
        }

        /// <summary>
        /// Return the correct fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <returns></returns>
        protected override TFact GetCorrectFact<TFact>(IFactContainer<TFactBase> container, IWantAction<TFactBase> wantAction)
        {
            if (wantAction is IFactTypeVersionInfo factType)
                return (TFact)container.GetRightFactByVersionType(GetFactType<TFact>(), factType.VersionType);

            return (TFact)container.GetRightFactByVersion(GetFactType<TFact>(), null);
        }
    }
}
