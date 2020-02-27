using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FactFactoryTests.FactContainer
{
    [TestClass]
    public sealed class FactContainerTests : TestBase
    {
        // TODO: Make container copy test
        private GivenBlock<GetcuReone.FactFactory.Entities.FactContainer> GivenCreateContainer()
        {
            return Given("Create container", () => new GetcuReone.FactFactory.Entities.FactContainer());
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Add fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddFactContainerTestCase()
        {
            DateTime operationDate = DateTime.Now;
            GivenCreateContainer()
                .When("Add fact", container => container.AddAndReturn(new StartDateOfDerive(operationDate)))
                .Then("Check contains fact", container =>
                {
                    foreach(var fact in container)
                    {
                        Assert.IsNotNull(fact, "fact can't should be null");
                        var dateOfDerive = fact as StartDateOfDerive;
                        Assert.IsNotNull(dateOfDerive, "dateOfDerive can't should be null");
                        Assert.AreEqual(operationDate, dateOfDerive.Value, "another fact value was expected");
                    }
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Container)]
        [Description("Add an existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddAnExistingFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Add an existing fact", container => ExpectedException<ArgumentException>(() => container.AddAndReturn(new IntFact(0))))
                .Then("Check error", ex =>
                {
                    Assert.IsNotNull(ex, "error can't should be null");
                    Assert.AreEqual($"The fact container already contains {typeof(IntFact).FullName} type of fact.", ex.Message, "Expected another message");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Contains fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void ContainsFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Contains", container => container.Contains<IntFact>())
                .Then("Check result", result => Assert.IsTrue(result, "fact not contained"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Not contains fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void NotContainsFactTestCase()
        {
            GivenCreateContainer()
                .When("Contains", container => container.Contains<IntFact>())
                .Then("Check result", result => Assert.IsFalse(result, "fact contained"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Remove fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RemoveFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Remove fact", container => container.RemoveAndReturn<IntFact>())
                .Then("Check fact", container => Assert.IsFalse(container.Contains<IntFact>()));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Try get existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void TryGetValueExistingFactTestCase()
        {
            var fact = new IntFact(0);

            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(fact))
                .When("Get value", ct =>
                {
                    bool isFind = ct.TryGetFact(out IntFact result);
                    return new { isFind, result };
                })
                .Then("Check result", result =>
                {
                    Assert.IsTrue(result.isFind, "fact not found");
                    Assert.AreEqual(fact, result.result, "return another fact");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Try get an existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void TryGetValueAnExistingFactTestCase()
        {
            GivenCreateContainer()
                .When("Get value", ct =>
                {
                    bool isFind = ct.TryGetFact(out IntFact result);
                    return new { isFind, result };
                })
                .Then("Check result", result =>
                {
                    Assert.IsFalse(result.isFind, "fact not found");
                    Assert.IsNull(result.result, "fact most be null");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Get existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetValueExistingFactTestCase()
        {
            var fact = new IntFact(0);

            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(fact))
                .When("Get value", ct => ct.GetFact<IntFact>())
                .Then("Check result", result =>
                {
                    Assert.AreEqual(fact, result, "return another fact");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Get an existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetValueAnExistingFactTestCase()
        {
            GivenCreateContainer()
                .When("Get value", ct => ExpectedException<FactNotFoundException<IntFact>>(() => ct.GetFact<IntFact>()))
                .Then("Check result", ex =>
                {
                    Assert.IsNotNull(ex, "error is null");
                });
        }
    }
}
