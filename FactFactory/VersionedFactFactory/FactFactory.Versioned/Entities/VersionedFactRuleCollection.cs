using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Collection of versioned rules for facts.
    /// </summary>
    public sealed class VersionedFactRuleCollection : VersionedFactRuleCollectionBase<VersionedFactRule>
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
        public VersionedFactRuleCollection(IEnumerable<VersionedFactRule> factRules) : base(factRules)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        public VersionedFactRuleCollection(IEnumerable<VersionedFactRule> factRules, bool isReadOnly) : base(factRules, isReadOnly)
        {
        }

        /// <summary>
        /// <see cref="FactRuleCollectionBase{TFactRule}"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="VersionedFactRuleCollection"/>.</returns>
        public override IFactRuleCollection<VersionedFactRule> Copy()
        {
            return new VersionedFactRuleCollection(this, IsReadOnly);
        }

        /// <summary>
        /// Creation method <see cref="VersionedFactRule"/>.
        /// </summary>
        /// <param name="func">func for calculate</param>
        /// <param name="inputFactTypes">information on input factacles rules.</param>
        /// <param name="outputFactType">information on output fact.</param>
        /// <returns></returns>
        protected override VersionedFactRule CreateFactRule(Func<IFactContainer, IWantAction, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            return new VersionedFactRule(func, inputFactTypes, outputFactType);
        }
    }
}
