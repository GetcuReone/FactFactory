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

        protected IWantActionContext GetWantActionContext(IWantAction wantAction, IFactContainer container, ISingleEntityOperations singleEntityOperations = null, IFactTypeCache cache = null)
        {
            return new WantActionContext
            {
                Cache = cache ?? GetFactTypeCache(),
                SingleEntityOperations = singleEntityOperations ?? GetFacade<SingleEntityOperationsFacade>(),
                WantAction = wantAction,
                Container = container,
            };
        }
    }
}
