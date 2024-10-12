using GetcuReone.FactFactory.Interfaces;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal sealed class FactRuleCollectionGetOriginal : Rules
    {
        public override IFactRuleCollection Copy()
        {
            return this;
        }
    }
}
