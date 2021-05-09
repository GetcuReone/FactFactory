using FactFactory.TestsCommon;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using F_EqualityComparer = GetcuReone.FactFactory.BaseEntities.FactEqualityComparer;

namespace GetcuReone.FactFactoryTests.FactEqualityComparer
{
    [TestClass]
    public abstract class FactEqualityComparerTestBase : CommonTestBase
    {
        protected GivenBlock<F_EqualityComparer, F_EqualityComparer> GivenCreateComparer()
        {
            return Given("Create cache.", () => new FactTypeCache())
                .AndIsNotNull()
                .And("Create FactEqualityComparer.", cache => new F_EqualityComparer(cache))
                .AndIsNotNull();
        }
    }
}
