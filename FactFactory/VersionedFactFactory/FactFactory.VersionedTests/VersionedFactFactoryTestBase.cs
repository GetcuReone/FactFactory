using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetcuReone.FactFactory;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;
using WAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;

namespace FactFactory.VersionedTests
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }
        protected IComparer<Rule> Comparer { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            Container = new Container(GetVersionFacts());
            WantAction = new WAction(ct => { }, new List<IFactType> { GetFactType<FactResult>() });
        }

        public virtual Rule GetFactRule<TFact>(Func<TFact> func)
            where TFact : VersionedFactBase
        {
            return new Rule(
                facts => func(),
                new List<IFactType> { },
                GetFactType<TFact>());
        }

        public virtual Rule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func)
            where TFact1 : IFact
            where TFactResult : VersionedFactBase
        {
            return new Rule(
                facts => func(facts.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>());
        }

        public virtual Rule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : VersionedFactBase
        {
            return new Rule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), },
                GetFactType<TFactResult>());
        }

        public virtual Rule GetFactRule<TFact1, TFact2, TFact3, TFactResult>(Func<TFact1, TFact2, TFact3, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFactResult : VersionedFactBase
        {
            return new Rule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), },
                GetFactType<TFactResult>());
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
