using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using FactFactoryTests.FactFactoryT.Helpers;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Container = GetcuReone.FactFactory.Entities.FactContainer;

namespace FactFactoryTests.FactContainer
{
    [TestClass]
    public sealed class FactContainerTests : CommonTestBase<FactBase>
    {
        private GivenBlock<Container> GivenCreateContainer(bool isReadOnly = false)
        {
            return Given("Create container", () => new Container(null, isReadOnly));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add an existing fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddAnExistingFactTestCase()
        {
            string expectedReason = $"The fact container already contains {GetFactType<IntFact>().FactName} type of fact.";

            GivenCreateContainer()
                .And("Add fact.", container => container.Add(new IntFact(0)))
                .When("Add an existing fact.", container => 
                    ExpectedFactFactoryException(() => container.Add(new IntFact(0))))
                .ThenAssertErrorDetail(ErrorCode.InvalidFactType, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Contains fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ContainsFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact.", container => 
                    container.Add(new IntFact(0)))
                .When("Contains.", container => 
                    container.Contains<IntFact>())
                .Then("Check result.", result => 
                    Assert.IsTrue(result, "Fact not contained."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Not contains fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void NotContainsFactTestCase()
        {
            GivenCreateContainer()
                .When("Contains.", container => 
                    container.Contains<IntFact>())
                .Then("Check result.", result => 
                    Assert.IsFalse(result, "Fact contained."));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact.", container => 
                    container.Add(new IntFact(0)))
                .When("Remove fact.", container => 
                    container.Remove<IntFact>())
                .Then("Check fact.", container => 
                    Assert.IsFalse(container.Contains<IntFact>()));
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Try get existing fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryGetValueExistingFactTestCase()
        {
            var fact = new IntFact(0);

            GivenCreateContainer()
                .And("Add fact.", container => 
                    container.Add(fact))
                .When("Get value.", ct =>
                {
                    bool isFind = ct.TryGetFact(out IntFact result);
                    return new { isFind, result };
                })
                .Then("Check result.", result =>
                {
                    Assert.IsTrue(result.isFind, "Fact not found.");
                    Assert.AreEqual(fact, result.result, "Return another fact.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Try get an existing fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void TryGetValueAnExistingFactTestCase()
        {
            GivenCreateContainer()
                .When("Get value.", ct =>
                {
                    bool isFind = ct.TryGetFact(out IntFact result);
                    return new { isFind, result };
                })
                .Then("Check result.", result =>
                {
                    Assert.IsFalse(result.isFind, "Fact not found.");
                    Assert.IsNull(result.result, "Fact most be null.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get existing fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetValueExistingFactTestCase()
        {
            const int expectedValue = 0;

            GivenCreateContainer()
                .And("Add fact.", container => container.Add(new IntFact(expectedValue)))
                .When("Get value.", ct => ct.GetFact<IntFact>())
                .ThenFactEquals(expectedValue);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get an existing fact.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetValueAnExistingFactTestCase()
        {
            string expectedReason = $"Not found type fact with type {GetFactType<IntFact>().FactName}.";

            GivenCreateContainer()
                .When("Get value", ct => 
                    ExpectedFactFactoryException(() => ct.GetFact<IntFact>()))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedReason);
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get copied container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void FactContainer_GetCopiedContainerTestCase()
        {
            Input1Fact input1Fact = new Input1Fact(1);
            Input2Fact input2Fact = new Input2Fact(2);
            Input3Fact input3Fact = new Input3Fact(3);

            Container originalContainer = null;
            IFactContainer<FactBase> copyContainer = null;

            Given("Create container.", () => originalContainer = new Container())
                .And("Add facts.", _ =>
                {
                    originalContainer.Add(input1Fact);
                    originalContainer.Add(input2Fact);
                    originalContainer.Add(input3Fact);
                })
                .When("Get value.", _ => copyContainer = originalContainer.Copy())
                .Then("Check result.", _ =>
                {
                    Assert.IsNotNull(copyContainer, "Container cannot be null.");
                    Assert.AreNotEqual(originalContainer, copyContainer, "Containers should not be equal.");
                    Assert.AreEqual(originalContainer.Count(), copyContainer.Count(), "Containers should have the same amount of facts.");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input1Fact fact1), $"{nameof(Input1Fact)} must be contained in a container.");
                    Assert.AreEqual(input1Fact, fact1, $"Original copy of {nameof(Input1Fact)} fact expected.");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input2Fact fact2), $"{nameof(Input2Fact)} must be contained in a container.");
                    Assert.AreEqual(input2Fact, fact2, $"Original copy of {nameof(Input2Fact)} fact expected.");

                    Assert.IsTrue(copyContainer.TryGetFact(out Input3Fact fact3), $"{nameof(Input3Fact)} must be contained in a container.");
                    Assert.AreEqual(input3Fact, fact3, $"Original copy of {nameof(Input3Fact)} fact expected.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add fact to read-only container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactReadOnlyContainerTestCase()
        {
            GivenCreateContainer(true)
                .When("Add fact.", container => 
                    ExpectedFactFactoryException(() => container.Add(new Input10Fact(10))))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove fact to read-only container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveFactReadOnlyContainerTestCase()
        {
            GivenCreateContainer(true)
                .When("Remove fact.", container => 
                    ExpectedFactFactoryException(() => container.Remove(new Input10Fact(10))))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, $"Fact container is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Objects.Container), TestCategory(GetcuReoneTC.Unit)]
        [Description("Clear container.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ClearContainerTestCase()
        {
            GivenCreateContainer()
                .And("Add fact.", container => container.Add(new IntFact(0)))
                .When("Clear.", container => container.Clear())
                .Then("Check result.",container => 
                {
                    Assert.AreEqual(0, container.Count(), "Container must be empty.");
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.Fact), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a fact that is not inherited from the base class and is not special.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddFactOfIFactTestCase()
        {
            var fact = new InvalidFact();
            string expectedMessage = $"The fact must be inherited either from the base type or from {nameof(ISpecialFact)}. Fact:<{fact}>.";

            GivenCreateContainer()
                .When("Add fact.", container =>
                    ExpectedFactFactoryException(() => container.Add(fact)))
                .ThenAssertErrorDetail(ErrorCode.InvalidData, expectedMessage);
        }
    }
}
