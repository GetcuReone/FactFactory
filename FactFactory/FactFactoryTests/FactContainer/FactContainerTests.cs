using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactContainer
{
    [TestClass]
    public sealed class FactContainerTests : CommonTestBase<FactBase>
    {
        // TODO: Make container copy test
        private GivenBlock<Container> GivenCreateContainer(bool isReadOnly = false)
        {
            return Given("Create container", () => new Container(null, isReadOnly));
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
        [TestCategory(TC.Negative), TestCategory(TC.Objects.Container)]
        [Description("Get an existing fact")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetValueAnExistingFactTestCase()
        {
            string expectedReason = $"Not found type fact with type {GetFactType<IntFact>().FactName}.";

            GivenCreateContainer()
                .When("Get value", ct => ExpectedFactFactoryException(() => ct.GetFact<IntFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Get copied container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void FactContainer_GetCopiedContainerTestCase()
        {
            Input1Fact input1Fact = new Input1Fact(1);
            Input2Fact input2Fact = new Input2Fact(2);
            Input3Fact input3Fact = new Input3Fact(3);

            Container originalContainer = null;
            IFactContainer<FactBase> copyContainer = null;

            Given("Create container", () => originalContainer = new Container())
                .And("Add facts", _ =>
                {
                    originalContainer.Add(input1Fact);
                    originalContainer.Add(input2Fact);
                    originalContainer.Add(input3Fact);
                })
                .When("Get value", _ => copyContainer = originalContainer.Copy())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(copyContainer, "container cannot be null");
                    Assert.AreNotEqual(originalContainer, copyContainer, "Containers should not be equal");
                    Assert.AreEqual(originalContainer.Count(), copyContainer.Count(), "Containers should have the same amount of facts");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input1Fact fact1), $"{nameof(Input1Fact)} must be contained in a container");
                    Assert.AreEqual(input1Fact, fact1, $"Original copy of {nameof(Input1Fact)} fact expected");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input2Fact fact2), $"{nameof(Input2Fact)} must be contained in a container");
                    Assert.AreEqual(input2Fact, fact2, $"Original copy of {nameof(Input2Fact)} fact expected");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input3Fact fact3), $"{nameof(Input3Fact)} must be contained in a container");
                    Assert.AreEqual(input3Fact, fact3, $"Original copy of {nameof(Input3Fact)} fact expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Add fact to read-only container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddFactReadOnlyContainerTestCase()
        {
            GivenCreateContainer(true)
                .When("Add fact", container => ExpectedFactFactoryException(() => container.Add(new Input10Fact(10))))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container)]
        [Description("Remove fact to read-only container")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RemoveFactReadOnlyContainerTestCase()
        {
            GivenCreateContainer(true)
                .When("Remove fact", container => ExpectedFactFactoryException(() => container.Remove(new Input10Fact(10))))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }
    }
}
