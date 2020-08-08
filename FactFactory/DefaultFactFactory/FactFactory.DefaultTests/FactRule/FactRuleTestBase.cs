using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.FactRule
{
    [TestClass]
    public abstract class FactRuleTestBase : CommonTestBase<FactBase>
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container();
            WantAction = new WAction(ct => { }, new List<IFactType> { GetFactType<ResultFact>() });
        }

        public virtual Rule GetFactRule<TFact>(Func<TFact> func)
            where TFact : FactBase
        {
            return new Rule(
                (container, _) => func(),
                new List<IFactType> { },
                GetFactType<TFact>());
        }

        public virtual Rule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func)
            where TFact1 : IFact
            where TFactResult : FactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>());
        }

        public virtual Rule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : FactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>(), container.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), },
                GetFactType<TFactResult>());
        }

        public virtual Rule GetFactRule<TFact1, TFact2, TFact3, TFactResult>(Func<TFact1, TFact2, TFact3, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFactResult : FactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), },
                GetFactType<TFactResult>());
        }
    }
}
