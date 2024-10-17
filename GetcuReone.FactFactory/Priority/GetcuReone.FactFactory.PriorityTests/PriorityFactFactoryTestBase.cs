using FactFactory.TestsCommon;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.PriorityTests
{
    [TestClass]
    public abstract class PriorityFactFactoryTestBase : CommonTestBase
    {
        protected override IWantActionContext GetWantActionContext(IWantAction wantAction, IFactContainer container, ISingleEntityOperations singleEntity = null, IFactTypeCache cache = null)
        {
            return base.GetWantActionContext(wantAction, container, singleEntity ?? new PrioritySingleEntityOperationsFacade(), cache);
        }
    }
}
