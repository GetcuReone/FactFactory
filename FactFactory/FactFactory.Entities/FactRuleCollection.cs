using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Collection for <see cref="FactRule"/>.
    /// </summary>
    public class FactRuleCollection : FactRuleCollectionBase<FactRule>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FactRuleCollection()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        public FactRuleCollection(IEnumerable<FactRule> factRules) : base(factRules)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        public FactRuleCollection(IEnumerable<FactRule> factRules, bool isReadOnly) : base(factRules, isReadOnly)
        {
        }

        /// <summary>
        /// <see cref="FactRuleCollectionBase{TFactRule}"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="FactRuleCollection"/>.</returns>
        public override IFactRuleCollection<FactRule> Copy()
        {
            return new FactRuleCollection(this, IsReadOnly);
        }

        /// <inheritdoc/>
        protected override FactRule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            return new FactRule(func, inputFactTypes, outputFactType);
        }
    }
}
