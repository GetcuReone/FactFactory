using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.VersionedTests
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            Container = new Container(GetVersionFacts());
            WantAction = new WAction(ct => { }, new List<IFactType> { GetFactType<FactResult>() });
        }

        public virtual WAction GetWantAction<TFact1>(Action<TFact1> action)
            where TFact1 : IFact
        {
            return new WAction(
                ct => action(ct.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>()});
        }

        public virtual WAction GetWantAction<TFact1, TFact2>(Action<TFact1, TFact2> action)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            return new WAction(
                ct => action(ct.GetFact<TFact1>(), ct.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() });
        }

        protected virtual List<IVersionFact> GetVersionFacts()
        {
            return new List<IVersionFact>
            {
                new Version1(),
                new Version2(),
            };
        }
    }
}
