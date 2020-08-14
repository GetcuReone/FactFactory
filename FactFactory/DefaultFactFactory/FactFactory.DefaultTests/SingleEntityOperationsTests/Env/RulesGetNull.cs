using GetcuReone.FactFactory.Interfaces;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal class RulesGetNull : Rules
    {
        public override IFactRuleCollection<GetcuReone.FactFactory.Entities.FactRule> Copy()
        {
            return null;
        }
    }
}
