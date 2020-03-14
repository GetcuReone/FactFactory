using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Default;
using Rule = GetcuReone.FactFactory.Default.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactRuleCollectionGetOriginal : GetcuReone.FactFactory.Default.Entities.FactRuleCollection
    {
        public override FactRuleCollectionBase<FactBase, Rule> Copy()
        {
            return this;
        }
    }
}
