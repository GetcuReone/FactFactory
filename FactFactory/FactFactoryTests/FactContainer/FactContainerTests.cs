﻿using FactFactory.Exceptions;
using FactFactory.Facts;
using FactFactoryTests.CommonFacts;
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
                .When("Add fact", container => container.AddAndReturn(new DateOfDeriveFact(operationDate)))
                .Then("Check contains fact", container =>
                {
                    foreach(var fact in container)
                    {
                        Assert.IsNotNull(fact, "fact can't should be null");
                        var dateOfDerive = fact as DateOfDeriveFact;
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

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] contains fact")]
        public void ContainsFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Contains", container => container.Contains<IntFact>())
                .Then("Check result", result => Assert.IsTrue(result, "fact not contained"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] not contains fact")]
        public void NotContainsFactTestCase()
        {
            GivenCreateContainer()
                .When("Contains", container => container.Contains<IntFact>())
                .Then("Check result", result => Assert.IsFalse(result, "fact contained"));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] remove fact")]
        public void RemoveFactTestCase()
        {
            GivenCreateContainer()
                .And("Add fact", container => container.AddAndReturn(new IntFact(0)))
                .When("Remove fact", container => container.RemoveAndReturn<IntFact>())
                .Then("Check fact", container => Assert.IsFalse(container.Contains<IntFact>()));
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] try get existing fact")]
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

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] try get an existing fact")]
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

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container] get existing fact")]
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

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][container][negative] get an existing fact")]
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