using FactFactory.Entities;

namespace FactFactory
{
    /// <inheritdoc />
    public class FactFactory : FactFactoryBase<FactContainer, FactRule, FactRuleCollection>
    {
        /// <inheritdoc />
        public override FactContainer Container { get; } = new FactContainer();

        /// <inheritdoc />
        public override FactRuleCollection Rules { get; } = new FactRuleCollection();
    }
}
