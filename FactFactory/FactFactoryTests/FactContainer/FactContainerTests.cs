using FactFactory.Entities;
using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactContainer
{
    [TestClass]
    public sealed class FactContainerTests : TestBase
    {
        private GivenBlock<FactFactory.Entities.FactContainer> GivenCreateContainer()
        {
            return Given("Create container", () => new FactFactory.Entities.FactContainer());
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] add fact")]
        public void AddFactContainerTestCase()
        {
            DateTime operationDate = DateTime.Now;
            GivenCreateContainer()
                .When("Add fact", container => container.AddAndReturn(new DateOfDerive(operationDate)))
                .Then("Check contains fact", container =>
                {
                    foreach(var fact in container)
                    {
                        Assert.IsNotNull(fact, "fact can't should be null");
                        var dateOfDerive = fact as DateOfDerive;
                        Assert.IsNotNull(dateOfDerive, "dateOfDerive can't should be null");
                        Assert.AreEqual(operationDate, dateOfDerive.Value, "another fact value was expected");
                    }
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container][negative] add an existing fact")]
        public void AddAnExistingFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Add an existing fact", container => ExpectedException<ArgumentException>(() => container.AddAndReturn(new IntFact(0))))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error can't should be null");
                });
        }
    }
}
