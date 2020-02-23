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
    }
}
