using FactFactory.TestsCommon;
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
            return Given("Create cache.", () => F_EqualityComparer.GetDefault())
                .AndIsNotNull();
        }
    }
}
