using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactRuleCollection
{
    [TestClass]
    public sealed class FactRuleCollectionTests : CommonTestBase<FactBase>
    {
        private Collection Collection { get; set; }

        private GivenBlock<Collection> GivenCreateCollection(bool isReadOnly)
        {
            return Given("Create collection", () => new Collection(null, isReadOnly));
        }

        [TestInitialize]
        public void Initialize()
        {
            Collection = new Collection();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule without input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 1 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 2 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 3 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 4 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 5 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 6 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 7 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 8 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 9 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 10 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 11 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 12 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input12Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 13 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input13Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 14 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input14Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 15 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input14Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input15Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with 16 input facts")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
                        new GetcuReone.FactFactory.Entities.FactType<Input1Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input2Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input3Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input4Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input5Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input6Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input7Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input8Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input9Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input10Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input11Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input12Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input13Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input14Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input15Fact>(),
                        new GetcuReone.FactFactory.Entities.FactType<Input16Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "a different number of input parameters was expected");
                    Assert.IsTrue(Collection[0].OutputFactType.Compare(new GetcuReone.FactFactory.Entities.FactType<ResultFact>()), "The derived fact is of the wrong type");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.Compare(factType)), $"No input fact information found {factType.FactName}");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Create a rule without param")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Add a rule with a NotContained on the output")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddRuleWithNotContainedOutTestCase()
        {
            GivenEmpty()
                .When("Add rule already contains", _ =>
                {
                    return ExpectedException<ArgumentException>(() => Collection.Add(() => new NotContained<Input10Fact>()));
                })
                .Then("Check error", ex => Assert.IsNotNull(ex, "error is null"));
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection)]
        [Description("Get copied collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void GetCopiedCollectionTestCase()
        {
            Rule factRule = null;

            Given("Create rule", () => factRule = new Rule(ct => default, new List<IFactType>(), GetFactType<Input1Fact>()))
                .And("Add rule", _ => Collection.Add(factRule))
                .When("Get copied", _ => Collection.Copy())
                .Then("Check result", copyCollection =>
                {
                    Assert.IsNotNull(copyCollection, "collection cannot be null");
                    Assert.AreNotEqual(Collection, copyCollection, "Collections should not be equal");
                    Assert.AreEqual(Collection.Count(), copyCollection.Count(), "Collections should have the same amount of rules");

                    Assert.AreEqual(factRule, copyCollection[0], "The collection contains another rule.");
                });
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Add rule to read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddRuleReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("Add rule", rules => ExpectedFactFactoryException(() => rules.Add(null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Remove rule to read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RemoveRuleReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("Remove rule", rules => ExpectedFactFactoryException(() => rules.Remove(null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Clear read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void ClearReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("Clear", rules => ExpectedFactFactoryException(() => rules.Clear()))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Insert rule to read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void InsertRuleReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("Insert rule", rules => ExpectedFactFactoryException(() => rules.Insert(0, null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("RemoveAt rule to read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void RemoveAtRuleReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("RemoveAt rule", rules => ExpectedFactFactoryException(() => rules.RemoveAt(0)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }

        [TestMethod]
        [TestCategory(TC.Negative), TestCategory(TC.Objects.RuleCollection)]
        [Description("Add by index rule to read-only collection")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void AddByIndexRuleReadOnlyCollectionTestCase()
        {
            GivenCreateCollection(true)
                .When("Add by index", rules => ExpectedFactFactoryException(() => rules[0] = null))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, "Rule collection is read-only.");
        }
    }
}
