using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactRuleCollectionGetOriginal : GetcuReone.FactFactory.Entities.FactRuleCollection
    {
        public override FactRuleCollectionBase<FactBase, Rule> Copy()
        {
            return this;
        }
    }
}
