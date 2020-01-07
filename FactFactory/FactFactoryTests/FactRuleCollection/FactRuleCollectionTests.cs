using FactFactory.Interfaces;
using FactFactoryTests.CommonFacts;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Collection = FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactRuleCollection
{
    [TestClass]
    public sealed class FactRuleCollectionTests : TestBase
    {
        private Collection Collection { get; set; }

        [TestInitialize]
        public void Initialaze()
        {
            Collection = new Collection();
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule without input facts")]
        public void AddRuleWithoutInputFactsTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add(() => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    Assert.AreEqual(1, Collection.Count, "collection is empty");
                    Assert.AreEqual(0, Collection[0].InputFactInfos.Count, "a different number of input parameters was expected");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 1 input facts")]
        public void AddRuleWith1InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 2 input facts")]
        public void AddRuleWith2InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 3 input facts")]
        public void AddRuleWith3InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 4 input facts")]
        public void AddRuleWith4InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 5 input facts")]
        public void AddRuleWith5InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 6 input facts")]
        public void AddRuleWith6InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 7 input facts")]
        public void AddRuleWith7InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 8 input facts")]
        public void AddRuleWith8InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 9 input facts")]
        public void AddRuleWith9InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 10 input facts")]
        public void AddRuleWith10InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 11 input facts")]
        public void AddRuleWith11InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 16 input facts")]
        public void AddRuleWith12InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                        new FactFactory.Entities.FactInfo<Input12Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 13 input facts")]
        public void AddRuleWith13InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                        new FactFactory.Entities.FactInfo<Input12Fact>(),
                        new FactFactory.Entities.FactInfo<Input13Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 14 input facts")]
        public void AddRuleWith14InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                        new FactFactory.Entities.FactInfo<Input12Fact>(),
                        new FactFactory.Entities.FactInfo<Input13Fact>(),
                        new FactFactory.Entities.FactInfo<Input14Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 15 input facts")]
        public void AddRuleWith15InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                        new FactFactory.Entities.FactInfo<Input12Fact>(),
                        new FactFactory.Entities.FactInfo<Input13Fact>(),
                        new FactFactory.Entities.FactInfo<Input14Fact>(),
                        new FactFactory.Entities.FactInfo<Input15Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }

        [Timeout(Timeouits.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule] Add a rule with 16 input facts")]
        public void AddRuleWith16InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15, Input16Fact fact16) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactInfo> inputFactInfos = Collection[0].InputFactInfos;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factInfos = new List<IFactInfo>
                    {
                        new FactFactory.Entities.FactInfo<Input1Fact>(),
                        new FactFactory.Entities.FactInfo<Input2Fact>(),
                        new FactFactory.Entities.FactInfo<Input3Fact>(),
                        new FactFactory.Entities.FactInfo<Input4Fact>(),
                        new FactFactory.Entities.FactInfo<Input5Fact>(),
                        new FactFactory.Entities.FactInfo<Input6Fact>(),
                        new FactFactory.Entities.FactInfo<Input7Fact>(),
                        new FactFactory.Entities.FactInfo<Input8Fact>(),
                        new FactFactory.Entities.FactInfo<Input9Fact>(),
                        new FactFactory.Entities.FactInfo<Input10Fact>(),
                        new FactFactory.Entities.FactInfo<Input11Fact>(),
                        new FactFactory.Entities.FactInfo<Input12Fact>(),
                        new FactFactory.Entities.FactInfo<Input13Fact>(),
                        new FactFactory.Entities.FactInfo<Input14Fact>(),
                        new FactFactory.Entities.FactInfo<Input15Fact>(),
                        new FactFactory.Entities.FactInfo<Input16Fact>(),
                    };

                    Assert.AreEqual(factInfos.Count, inputFactInfos.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactInfo.Compare(new FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactInfo factInfo in factInfos)
                        Assert.IsTrue(inputFactInfos.Any(item => item.Compare(factInfo)), $"No input fact information found {factInfo.FactName}");
                });
        }
    }
}
