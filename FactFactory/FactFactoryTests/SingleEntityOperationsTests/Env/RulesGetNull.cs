using GetcuReone.FactFactory.Interfaces;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.SingleEntityOperationsTests.Env
{
    internal class RulesGetNull : Rules
    {
        public override IFactRuleCollection Copy()
        {
            return null;
        }
    }
}
