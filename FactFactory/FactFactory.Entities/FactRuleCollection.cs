using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <inheritdoc/>
        public FactRuleCollection(IEnumerable<FactRule> factRules) : base(factRules)
        {
        }

        /// <inheritdoc/>
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
        protected override FactRule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
        {
            return new FactRule(func, inputFactTypes, outputFactType, option);
        }

        /// <inheritdoc/>
        protected override FactRule CreateFactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
        {
            return new FactRule(func, inputFactTypes, outputFactType, option);
        }
    }
}
