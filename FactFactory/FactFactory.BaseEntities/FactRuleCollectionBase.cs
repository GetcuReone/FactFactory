using System;
using System.Collections.Generic;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactRuleCollection (deprecated in 4.0.2)")]
    public abstract class FactRuleCollectionBase<TFactRule>: BaseFactRuleCollection<TFactRule>
        where TFactRule : IFactRule
    {

        /// <inheritdoc/>
        protected FactRuleCollectionBase() : base(null)
        {
        }

        /// <inheritdoc/>
        protected FactRuleCollectionBase(IEnumerable<TFactRule> factRules) : base(factRules, false)
        {
        }

        /// <inheritdoc/>
        protected FactRuleCollectionBase(IEnumerable<TFactRule> factRules, bool isReadOnly) : base(factRules, isReadOnly)
        {
        }
    }
}
