using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class RulesGetNull : Rules
    {
        public override IFactRuleCollection<FactBase, GetcuReone.FactFactory.Entities.FactRule> Copy()
        {
            return null;
        }
    }
}
