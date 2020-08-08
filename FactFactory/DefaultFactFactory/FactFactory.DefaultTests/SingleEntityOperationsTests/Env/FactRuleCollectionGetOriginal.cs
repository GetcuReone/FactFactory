using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using Rules = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    internal sealed class FactRuleCollectionGetOriginal : Rules
    {
        public override IFactRuleCollection<FactBase, Rule> Copy()
        {
            return this;
        }
    }
}
