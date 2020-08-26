using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactRule
{
    [TestClass]
    public abstract class FactRuleTestBase : CommonTestBase
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container();
            WantAction = new WAction(ct => { }, new List<IFactType> { GetFactType<ResultFact>() });
        }
    }
}
