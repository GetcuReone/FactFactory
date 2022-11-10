using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations.Entities;
using System.Collections.Generic;
using Action = GetcuReone.FactFactory.Entities.WantAction;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactFactoryCustom : BaseFactFactory<Rule, Collection>
    {
        public List<WantFactsInfo> W_FactsInfos => WantFactsInfos;

        public override Collection Rules => collection;
        internal Collection collection = new Collection();

        internal List<BaseFact> DefaultFacts { get; } = new List<BaseFact>();

        protected override IEnumerable<IFact> GetDefaultFacts(IWantActionContext context)
        {
            return DefaultFacts;
        }

        protected override IFactContainer GetDefaultContainer()
        {
            return new Container();
        }
    }
}
