using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Base collection for <typeparamref name="TFactRule"/>.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    /// <typeparam name="TFactRule"></typeparam>
    public abstract class VersionedFactRuleCollectionBase<TFactBase, TFactRule> : FactRuleCollectionBase<TFactBase, TFactRule>
        where TFactBase : IVersionedFact
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
    }
}
