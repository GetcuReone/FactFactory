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
    public class FactRuleCollection : BaseFactRuleCollection<FactRule>
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

        /// <inheritdoc/>
        protected override IFactRuleCollection<FactRule> Empty()
        {
            return new FactRuleCollection(null, IsReadOnly);
        }
    }
}
