using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactRuleCollectionGetOriginal : GetcuReone.FactFactory.Entities.FactRuleCollection
    {
        public override IFactRuleCollection<FactBase, Rule> Copy()
        {
            return this;
        }
    }
}
