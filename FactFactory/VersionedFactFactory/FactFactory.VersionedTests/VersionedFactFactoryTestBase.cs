using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Entities;
using GetcuReone.FactFactory.Versioned.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;
using Rule = GetcuReone.FactFactory.Versioned.Entities.VersionedFactRule;
using WAction = GetcuReone.FactFactory.Versioned.Entities.VersionedWantAction;

namespace FactFactory.VersionedTests
{
    [TestClass]
    public abstract class VersionedFactFactoryTestBase : CommonTestBase<VersionedFactBase>
    {
        protected Container Container { get; private set; }
        protected WAction WantAction { get; private set; }
        protected IComparer<Rule> Comparer { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Container = new Container(GetVersionFacts());
            WantAction = new WAction(ct => { }, new List<IFactType> { GetFactType<FactResult>() });
            Comparer = new VersionedFactRuleComparer<VersionedFactBase, Rule, WAction, Container>(WantAction, Container);
        }

        public virtual Rule GetFactRule<TFact>(Func<TFact> func)
            where TFact : VersionedFactBase
        {
            return new Rule(
                (container, _) => func(),
                new List<IFactType> { },
                GetFactType<TFact>());
        }

        public virtual Rule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func)
            where TFact1 : IFact
            where TFactResult : VersionedFactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>());
        }

        public virtual Rule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : VersionedFactBase
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
            where TFactResult : VersionedFactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>(), container.GetFact<TFact2>(), container.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>(), },
                GetFactType<TFactResult>());
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
