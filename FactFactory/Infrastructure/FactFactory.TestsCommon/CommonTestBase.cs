using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.BaseEntities.Context;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.GetcuTestAdapter;
using System;

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

        protected IWantActionContext<TWantAction, TFactContainer> GetWantActionContext<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container, ISingleEntityOperations singleEntity = null, IFactTypeCache cache = null)
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
    }
}
