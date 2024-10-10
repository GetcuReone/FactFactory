using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactory.VersionedTests.VersionedFactFactory;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Versioned.Extensions;
using GetcuReone.FactFactory.Versioned.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.FactFactory.VersionedTests.VersionedFactFactory.Bug367
{
    [TestClass]
    public sealed class Bug367Tests : BaseVersionedFactFactoryTests
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("System.NullReferenceException: Object reference not set to an instance of an object (test for bug 367).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Bug367Test()
        {
            var container = new FactContainer
            {
                new TestObj(new object()),
                new Version367(),
            };

            GivenCreateVersionedFactFactory()
                .AndAddRules(new FactRuleCollection
                {
                    (Version367 v, TestObj obj) =>
                    {
                        return new TestObj_HashCode(1);
                    }
                })
                .When("Derive fact.", factory => factory.DeriveFact<TestObj_HashCode, Version367>(container))
                .ThenAreEqual(fact => fact.Value, 1)
                .Run();

        }
    }

    public sealed class Version367 : BaseIntVersion
    {
        public Version367() : base(367) { }
    }

    internal sealed class TestObj_HashCode : BaseFact<long>
    {
        public TestObj_HashCode(long value) : base(value) { }
    }

    internal sealed class TestObj : BaseFact<object>
    {
        public TestObj(object value) : base(value) { }
    }
}
