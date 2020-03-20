using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal class RulesGetNull : Rules
    {
        public override FactRuleCollectionBase<FactBase, GetcuReone.FactFactory.Entities.FactRule> Copy()
        {
            return null;
        }
    }
}
