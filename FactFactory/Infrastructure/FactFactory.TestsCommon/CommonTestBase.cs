using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.GetcuTestAdapter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactFactory.TestsCommon
{
    public abstract class CommonTestBase : GetcuReoneTestBase, IFactTypeCreation
    {
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        protected FactFactoryException ExpectedFactFactoryException(Action action)
        {
            return ExpectedException<FactFactoryException>(action);
        }

        protected InvalidDeriveOperationException ExpectedDeriveException(Action action)
        {
            return ExpectedException<InvalidDeriveOperationException>(action);
        }

        protected IFactTypeCache GetFactTypeCache()
        {
            return new FactTypeCache();
        }

        protected virtual IWantActionContext<TWantAction, TFactContainer> GetWantActionContext<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container, ISingleEntityOperations singleEntity = null, IFactTypeCache cache = null)
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return new WantActionContext<TWantAction, TFactContainer>
            {
                Cache = cache ?? GetFactTypeCache(),
                SingleEntity = singleEntity ?? GetFacade<SingleEntityOperationsFacade>(),
                WantAction = wantAction,
                Container = container,
            };
        }

        protected FactRule GetFactRule<TFactResult>(Func<TFactResult> func)
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(),
                new List<IFactType>(),
                GetFactType<TFactResult>());
        }

        protected FactRule GetFactRule<TFact1, TFactResult>(Func<TFact1, TFactResult> func)
            where TFact1 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() },
                GetFactType<TFactResult>());
        }

        protected FactRule GetFactRule<TFact1, TFact2, TFactResult>(Func<TFact1, TFact2, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() },
                GetFactType<TFactResult>());
        }

        protected FactRule GetFactRule<TFact1, TFact2, TFact3, TFactResult>(Func<TFact1, TFact2, TFact3, TFactResult> func)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
            where TFactResult : IFact
        {
            return new FactRule(
                facts => func(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() },
                GetFactType<TFactResult>());
        }

        protected WantAction GetWantAction<TFact1>(Action<TFact1> action)
            where TFact1 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>()),
                new List<IFactType> { GetFactType<TFact1>() });
        }

        protected WantAction GetWantAction<TFact1, TFact2>(Action<TFact1, TFact2> action)
            where TFact1 : IFact
            where TFact2 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>(), facts.GetFact<TFact2>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>() });
        }

        protected WantAction GetWantAction<TFact1, TFact2, TFact3>(Action<TFact1, TFact2, TFact3> action)
            where TFact1 : IFact
            where TFact2 : IFact
            where TFact3 : IFact
        {
            return new WantAction(
                facts => action(facts.GetFact<TFact1>(), facts.GetFact<TFact2>(), facts.GetFact<TFact3>()),
                new List<IFactType> { GetFactType<TFact1>(), GetFactType<TFact2>(), GetFactType<TFact3>() });
        }
    }
}
