using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Entities.FactContainer;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.WantAction
{
    [TestClass]
    [Ignore]
    public sealed class WantActionSortTests : CommonTestBase
    {
        private Container Container { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container();
        }

        private WAction GetWantAction<TFact>(Action<TFact> action)
            where TFact : FactBase
        {
            return new WAction(
                container => action(container.GetFact<TFact>()),
                new List<IFactType> { GetFactType<TFact>() });
        }
    }
}
