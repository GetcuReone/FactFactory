using System.Collections.Generic;
using System.Collections.ObjectModel;
using FactFactory.Entities;

namespace FactFactory
{
    /// <inheritdoc />
    public class FactFactory : FactFactoryBase<FactContainer, FactRule, FactRuleCollection>
    {
        private ReadOnlyCollection<FactRule> _tempRule;
        /// <inheritdoc />
        public override FactContainer Container { get; } = new FactContainer();

        /// <inheritdoc />
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();

        /// <inheritdoc />
        public override void Derive()
        {
            _tempRule = new ReadOnlyCollection<FactRule>(Rules);

            base.Derive();

            _tempRule = null;
        }

        /// <inheritdoc />
        protected override IReadOnlyCollection<FactRule> GetRulesForDerive(WantAction wantAction)
        {
            return _tempRule;
        }

        /// <inheritdoc />
        protected override FactContainer GetCopyFactContainer()
        {
            return new FactContainer(Container);
        }
    }
}
