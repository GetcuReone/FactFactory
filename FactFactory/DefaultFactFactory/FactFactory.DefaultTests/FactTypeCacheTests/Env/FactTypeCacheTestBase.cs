using FactFactory.TestsCommon;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactory.DefaultTests.FactTypeCacheTests.Env
{
    [TestClass]
    public abstract class FactTypeCacheTestBase : CommonTestBase<FactBase>
    {
        protected virtual GivenBlock<IFactTypeCache> GivenCreateCahce()
        {
            return Given("Create fact type cache.", () => (IFactTypeCache)new FactTypeCache());
        }
    }
}
