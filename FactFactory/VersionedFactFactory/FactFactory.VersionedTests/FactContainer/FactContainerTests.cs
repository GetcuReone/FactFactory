using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactory.VersionedTests.FactContainer
{
    [TestClass]
    public sealed class FactContainerTests : CommonTestBase
    {
        private GivenBlock<Container> GivenCreateContainer()
        {
            return Given("Create container", () => new Container());
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add versioned fact to container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddVersionedFactContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container => container.Add(new Version1()))
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container");
                });
        }

        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two versioned facts to the container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddTwoVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container => 
                {
                    container.Add(new Version1());
                    container.Add(new Version2());
                })
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<Version1>(), "Version fact not contained in container");
                    Assert.IsTrue(container.Contains<Version2>(), "Version fact not contained in container");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Container)]
        [Description("Add two identical versioned facts to the container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddTwoIdenticalVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .And("first addition of versioned fact", container => container.Add(new Version1()))
                .When("second addition of versioned fact", container => ExpectedException<ArgumentException>(() => container.Add(new Version1())))
                .Then("Check result", error =>
                {
                    Assert.IsNotNull(error, "error can't should be null");
                    Assert.AreEqual($"The fact container already contains {typeof(Version1).FullName} type of fact.", error.Message, "Expected another message");
                });
        }
    }
}
