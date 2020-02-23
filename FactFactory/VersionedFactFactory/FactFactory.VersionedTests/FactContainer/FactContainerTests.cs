using FactFactory.VersionedTests.CommonFacts;
using FactFactoryTestsCommon;
using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule][container] add versioned fact to container")]
        public void AddVersionedFactContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container => container.Add(new V1()))
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<V1>(), "Version fact not contained in container");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule][container] add two versioned facts to the container")]
        public void AddTwoVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .When("added versioned fact", container => 
                {
                    container.Add(new V1());
                    container.Add(new V2());
                })
                .Then("Check result", container =>
                {
                    Assert.IsTrue(container.Contains<V1>(), "Version fact not contained in container");
                    Assert.IsTrue(container.Contains<V2>(), "Version fact not contained in container");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[versioned][rule][container][negative] add two identical versioned facts to the container")]
        public void AddTwoIdenticalVersionedFactsContainerTestCase()
        {
            GivenCreateContainer()
                .And("first addition of versioned fact", container => container.Add(new V1()))
                .When("second addition of versioned fact", container => ExpectedException<ArgumentException>(() => container.Add(new V1())))
                .Then("Check result", error =>
                {
                    Assert.IsNotNull(error, "error can't should be null");
                    Assert.AreEqual($"The fact container already contains {typeof(V1).FullName} type of fact.", error.Message, "Expected another message");
                });
        }
    }
}
