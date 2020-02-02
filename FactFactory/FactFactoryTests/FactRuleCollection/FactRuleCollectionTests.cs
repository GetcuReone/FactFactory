using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;

namespace FactFactoryTests.FactRuleCollection
{
    [TestClass]
    public sealed class FactRuleCollectionTests : TestBase
    {
        private Collection Collection { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Collection = new Collection();
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule without input facts")]
        public void AddRuleWithoutInputFactsTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add(() => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    Assert.AreEqual(1, Collection.Count, "collection is empty");
                    Assert.AreEqual(0, Collection[0].InputFactTypes.Count, "a different number of input parameters was expected");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 1 input facts")]
        public void AddRuleWith1InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 2 input facts")]
        public void AddRuleWith2InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 3 input facts")]
        public void AddRuleWith3InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 4 input facts")]
        public void AddRuleWith4InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 5 input facts")]
        public void AddRuleWith5InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 6 input facts")]
        public void AddRuleWith6InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 7 input facts")]
        public void AddRuleWith7InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 8 input facts")]
        public void AddRuleWith8InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 9 input facts")]
        public void AddRuleWith9InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 10 input facts")]
        public void AddRuleWith10InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 11 input facts")]
        public void AddRuleWith11InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 16 input facts")]
        public void AddRuleWith12InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input12Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 13 input facts")]
        public void AddRuleWith13InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input13Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 14 input facts")]
        public void AddRuleWith14InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input14Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 15 input facts")]
        public void AddRuleWith15InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input14Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input15Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][coolection] Add a rule with 16 input facts")]
        public void AddRuleWith16InputFactTestCase()
        {
            Given("Check count collection", () => Assert.AreEqual(0, Collection.Count, "collection is not empty"))
                .When("Add rule", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15, Input16Fact fact16) => new ResultFact(default)))
                .Then("Check collection", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty");

                    var factTypes = new List<IFactType>
                    {
                        new GetcuReone.FactFactory.Entities.FactInfo<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input14Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input15Fact>(),
                        new GetcuReone.FactFactory.Entities.FactInfo<Input16Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative][coolection] create a rule without param")]
        public void AddRuleAlreadyContainsTestCase()
        {
            GivenEmpty()
                .And("Add rule", _ => Collection.Add(() => new Input10Fact(10)))
                .When("Add rule already contains", _ =>
                {
                    return ExpectedException<ArgumentException>(() => Collection.Add(() => new Input10Fact(11)));
                })
                .Then("Check error", ex => Assert.IsNotNull(ex, "error is null"));
        }

        [Timeout(Timeouts.MilliSecond.Hundred)]
        [TestMethod]
        [Description("[fact][rule][negative][coolection] add a rule with a NotContained on the output")]
        public void AddRuleWithNotContainedOutTestCase()
        {
            GivenEmpty()
                .When("Add rule already contains", _ =>
                {
                    return ExpectedException<ArgumentException>(() => Collection.Add(() => new NotContained<Input10Fact>()));
                })
                .Then("Check error", ex => Assert.IsNotNull(ex, "error is null"));
        }
    }
}
