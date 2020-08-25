using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Collection of versioned rules for facts.
    /// </summary>
    public sealed class VersionedFactRuleCollection : VersionedFactRuleCollectionBase<FactRule>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public VersionedFactRuleCollection()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        public VersionedFactRuleCollection(IEnumerable<FactRule> factRules) : base(factRules)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        public VersionedFactRuleCollection(IEnumerable<FactRule> factRules, bool isReadOnly) : base(factRules, isReadOnly)
        {
        }

        /// <summary>
        /// <see cref="FactRuleCollectionBase{TFactRule}"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="VersionedFactRuleCollection"/>.</returns>
        public override IFactRuleCollection<FactRule> Copy()
        {
            return new VersionedFactRuleCollection(this, IsReadOnly);
        }

        /// <inheritdoc/>
        protected override FactRule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            return new FactRule(func, inputFactTypes, outputFactType);
        }
    }
}
