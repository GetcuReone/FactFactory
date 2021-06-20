using FactFactory.TestsCommon;
using FactFactory.TestsCommon.Helpers;
using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Rule = GetcuReone.FactFactory.Entities.FactRule;

namespace FactFactoryTests.FactRuleCollection
{
    [TestClass]
    public sealed class FactRuleCollectionTests : CommonTestBase
    {
        private Collection Collection { get; set; }

        private GivenBlock<object, Collection> GivenCreateCollection(bool isReadOnly)
        {
            return Given("Create collection", () => new Collection(null, isReadOnly));
        }

        [TestInitialize]
        public void Initialize()
        {
            Collection = new Collection();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule without input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWithoutInputFactsTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => 
                    Collection.Add(() => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");
                    Assert.AreEqual(0, Collection[0].InputFactTypes.Count, "Different number of input parameters was expected.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 1 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith1InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => 
                    Collection.Add((Input1Fact fact1) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 2 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith2InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => 
                    Collection.Add((Input1Fact fact1, Input2Fact fact2) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 3 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith3InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => 
                    Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 4 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith4InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        new FactType<Input1Fact>(),
                        new FactType<Input2Fact>(),
                        new FactType<Input3Fact>(),
                        new FactType<Input4Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 5 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith5InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 6 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith6InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 7 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith7InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 8 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith8InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 9 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith9InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 10 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith10InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 11 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith11InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 12 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith12InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                        GetFactType<Input12Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 13 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith13InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                        GetFactType<Input12Fact>(),
                        GetFactType<Input13Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 14 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith14InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                        GetFactType<Input12Fact>(),
                        GetFactType<Input13Fact>(),
                        GetFactType<Input14Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 15 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith15InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                        GetFactType<Input12Fact>(),
                        GetFactType<Input13Fact>(),
                        GetFactType<Input14Fact>(),
                        GetFactType<Input15Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with 16 input facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWith16InputFactTestCase()
        {
            Given("Check count collection.", () => Assert.AreEqual(0, Collection.Count, "Collection is not empty."))
                .When("Add rule.", _ => Collection.Add((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15, Input16Fact fact16) => new ResultFact(default)))
                .Then("Check collection.", _ =>
                {
                    IReadOnlyCollection<IFactType> inpuTFactTypes = Collection[0].InputFactTypes;
                    Assert.AreEqual(1, Collection.Count, "Collection is empty.");

                    var factTypes = new List<IFactType>
                    {
                        GetFactType<Input1Fact>(),
                        GetFactType<Input2Fact>(),
                        GetFactType<Input3Fact>(),
                        GetFactType<Input4Fact>(),
                        GetFactType<Input5Fact>(),
                        GetFactType<Input6Fact>(),
                        GetFactType<Input7Fact>(),
                        GetFactType<Input8Fact>(),
                        GetFactType<Input9Fact>(),
                        GetFactType<Input10Fact>(),
                        GetFactType<Input11Fact>(),
                        GetFactType<Input12Fact>(),
                        GetFactType<Input13Fact>(),
                        GetFactType<Input14Fact>(),
                        GetFactType<Input15Fact>(),
                        GetFactType<Input16Fact>(),
                    };

                    Assert.AreEqual(factTypes.Count, inpuTFactTypes.Count, "Different number of input parameters was expected.");
                    Assert.IsTrue(Collection[0].OutputFactType.EqualsFactType(GetFactType<ResultFact>()), "The derived fact is of the wrong type.");


                    foreach (IFactType factType in factTypes)
                        Assert.IsTrue(inpuTFactTypes.Any(item => item.EqualsFactType(factType)), $"No input fact information found {factType.FactName}.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Create a rule without param.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleAlreadyContainsTestCase()
        {
            GivenEmpty()
                .And("Add rule.", _ => 
                    Collection.Add(() => new Input10Fact(10)))
                .When("Add rule already contains", _ =>
                {
                    return ExpectedException<ArgumentException>(() => Collection.Add(() => new Input10Fact(11)));
                })
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add a rule with a BuildNotContained on the output.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleWithBuildNotContainedOutTestCase()
        {
            GivenEmpty()
                .When("Add rule already contains", _ =>
                {
                    return ExpectedException<ArgumentException>(() => Collection.Add(() => new BuildNotContained<Input10Fact>()));
                })
                .ThenIsNotNull()
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get copied collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void GetCopiedCollectionTestCase()
        {
            Rule factRule = null;

            Given("Create rule", () => factRule = GetFactRule(() => new Input1Fact(default)))
                .And("Add rule.", _ => 
                    Collection.Add(factRule))
                .When("Get copied.", _ => 
                    Collection.Copy())
                .ThenIsNotNull()
                .AndAreNotEqual(Collection)
                .And("Check result", copyCollection => 
                {
                    Assert.AreEqual(Collection.Count, copyCollection.Count, "Collections should have the same amount of rules.");
                    Assert.AreEqual(factRule, copyCollection[0], "The collection contains another rule.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add rule to read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddRuleReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("Add rule.", rules => 
                    ExpectedFactFactoryException(() => rules.Add(null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove rule to read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveRuleReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("Remove rule", rules => 
                    ExpectedFactFactoryException(() => rules.Remove(null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Clear read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ClearReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("Clear", rules => 
                    ExpectedFactFactoryException(() => rules.Clear()))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Insert rule to read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void InsertRuleReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("Insert rule", rules => 
                    ExpectedFactFactoryException(() => rules.Insert(0, null)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("RemoveAt rule to read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveAtRuleReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("RemoveAt rule", rules => 
                    ExpectedFactFactoryException(() => rules.RemoveAt(0)))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(TC.Objects.RuleCollection), TestCategory(GetcuReoneTC.Unit)]
        [Description("Add by index rule to read-only collection.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void AddByIndexRuleReadOnlyCollectionTestCase()
        {
            const string expectedReason = "Rule collection is read-only.";

            GivenCreateCollection(true)
                .When("Add by index", rules => ExpectedFactFactoryException(() => rules[0] = null))
                .ThenAssertErrorDetail(ErrorCode.InvalidOperation, expectedReason)
                .Run();
        }
    }
}
