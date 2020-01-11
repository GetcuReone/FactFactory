using System.Collections.Generic;
using FactFactory.Entities;

namespace FactFactory
{
    /// <inheritdoc />
    public class FactFactory : FactFactoryBase<FactContainer, FactRule, FactRuleCollection>
    {
        private FactRuleCollection _tempRule;
        /// <inheritdoc />
        public override FactContainer Container { get; } = new FactContainer();

        /// <inheritdoc />
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();

        /// <inheritdoc />
        public override void Derive()
        {
            _tempRule = new FactRuleCollection(Rules);

            base.Derive();

            _tempRule.Clear();
            _tempRule = null;
        }

        /// <inheritdoc />
        public override IEnumerable<FactRule> GetRulesForDerive(WantAction wantAction)
        {
            return _tempRule;
        }
    }
}
