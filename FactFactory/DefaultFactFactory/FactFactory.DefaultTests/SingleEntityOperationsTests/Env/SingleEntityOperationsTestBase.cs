using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Rule = GetcuReone.FactFactory.Entities.FactRule;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactory.DefaultTests.SingleEntityOperationsTests.Env
{
    [TestClass]
    public abstract class SingleEntityOperationsTestBase : CommonTestBase<FactBase>
    {
        protected virtual GivenBlock<SingleEntityOperationsFacade> GivenCreateFacade()
        {
            return Given("Create SingleEntityOperationsFacade", () => GetFacade<SingleEntityOperationsFacade>());
        }

        protected virtual Rule GetFactRule<TFact>(Func<TFact> func)
            where TFact : FactBase
        {
            return new Rule(
                (container, _) => func(),
                new List<IFactType> { },
                GetFactType<TFact>());
        }

        protected virtual Rule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func)
            where TFact1 : IFact
            where TFactResult : FactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>());
        }

        protected virtual Rule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : FactBase
        {
            return new Rule(
                (container, _) => func(container.GetFact<TFact1>(), container.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), },
                GetFactType<TFactResult>());
        }

        protected virtual Rule GetFactRule<TFact1, TFact2, TFact3, TFactResult>(Func<TFact1, TFact2, TFact3, TFactResult> func)
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

        protected virtual WAction GetWantAction<TFact>(Action<TFact> action)
            where TFact : FactBase
        {
            return new WAction(
                container => action(container.GetFact<TFact>()),
                new List<IFactType> { GetFactType<TFact>() });
        }
    }
}
