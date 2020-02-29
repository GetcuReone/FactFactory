using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactFactoryT.Env
{
    internal sealed class FactRuleCollectionGetOriginal : FactRuleCollectionBase<FactBase, Rule>
    {
        public override FactRuleCollectionBase<FactBase, Rule> Copy()
        {
            return this;
        }

        protected override Rule CreateFactRule(Func<IFactContainer<FactBase>, FactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            throw new NotImplementedException();
        }
    }
}
