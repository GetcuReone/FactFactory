using FactFactory.TestsCommon;
using FactFactoryTests.CommonFacts;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFactoryTests.FactFactoryT
{
    [TestClass]
    public sealed class WantFactTests : FactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 1 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want1FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                })
                .And("Want 1 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1) =>
                    {
                        input1Fact = fact1;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 2 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want2FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                })
                .And("Want 2 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 3 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want3FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                })
                .And("Want 3 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 4 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want4FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                })
                .And("Want 4 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 5 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want5FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                })
                .And("Want 5 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 6 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want6FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                })
                .And("Want 10 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 7 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want7FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                })
                .And("Want 7 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 8 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want8FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                })
                .And("Want 8 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 9 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want9FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                })
                .And("Want 10 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 10 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want10FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                })
                .And("Want 10 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 11 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want11FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                })
                .And("Want 11 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                        input11Fact = fact11;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 12 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want12FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;
            Input12Fact input12Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                    factory.Rules.Add((Input12Fact fact) => new Input13Fact(fact.Value + 1));
                })
                .And("Want 12 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                        input11Fact = fact11;
                        input12Fact = fact12;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");
                    Assert.IsNotNull(input12Fact, "input12Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                    Assert.AreEqual(startValue + 12, input12Fact.Value, "another input12Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 13 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want13FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;
            Input12Fact input12Fact = null;
            Input13Fact input13Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                    factory.Rules.Add((Input12Fact fact) => new Input13Fact(fact.Value + 1));
                    factory.Rules.Add((Input13Fact fact) => new Input14Fact(fact.Value + 1));
                })
                .And("Want 13 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                        input11Fact = fact11;
                        input12Fact = fact12;
                        input13Fact = fact13;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");
                    Assert.IsNotNull(input12Fact, "input12Fact cannot be null");
                    Assert.IsNotNull(input13Fact, "input13Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                    Assert.AreEqual(startValue + 12, input12Fact.Value, "another input12Fact value was expected");
                    Assert.AreEqual(startValue + 13, input13Fact.Value, "another input13Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 14 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want14FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;
            Input12Fact input12Fact = null;
            Input13Fact input13Fact = null;
            Input14Fact input14Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                    factory.Rules.Add((Input12Fact fact) => new Input13Fact(fact.Value + 1));
                    factory.Rules.Add((Input13Fact fact) => new Input14Fact(fact.Value + 1));
                    factory.Rules.Add((Input14Fact fact) => new Input15Fact(fact.Value + 1));
                })
                .And("Want 14 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                        input11Fact = fact11;
                        input12Fact = fact12;
                        input13Fact = fact13;
                        input14Fact = fact14;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");
                    Assert.IsNotNull(input12Fact, "input12Fact cannot be null");
                    Assert.IsNotNull(input13Fact, "input13Fact cannot be null");
                    Assert.IsNotNull(input14Fact, "input14Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                    Assert.AreEqual(startValue + 12, input12Fact.Value, "another input12Fact value was expected");
                    Assert.AreEqual(startValue + 13, input13Fact.Value, "another input13Fact value was expected");
                    Assert.AreEqual(startValue + 14, input14Fact.Value, "another input14act value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 15 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want15FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;
            Input12Fact input12Fact = null;
            Input13Fact input13Fact = null;
            Input14Fact input14Fact = null;
            Input15Fact input15Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                    factory.Rules.Add((Input12Fact fact) => new Input13Fact(fact.Value + 1));
                    factory.Rules.Add((Input13Fact fact) => new Input14Fact(fact.Value + 1));
                    factory.Rules.Add((Input14Fact fact) => new Input15Fact(fact.Value + 1));
                })
                .And("Want 15 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15) =>
                    {
                        input1Fact = fact1;
                        input2Fact = fact2;
                        input3Fact = fact3;
                        input4Fact = fact4;
                        input5Fact = fact5;
                        input6Fact = fact6;
                        input7Fact = fact7;
                        input8Fact = fact8;
                        input9Fact = fact9;
                        input10Fact = fact10;
                        input11Fact = fact11;
                        input12Fact = fact12;
                        input13Fact = fact13;
                        input14Fact = fact14;
                        input15Fact = fact15;
                    });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");
                    Assert.IsNotNull(input12Fact, "input12Fact cannot be null");
                    Assert.IsNotNull(input13Fact, "input13Fact cannot be null");
                    Assert.IsNotNull(input14Fact, "input14Fact cannot be null");
                    Assert.IsNotNull(input15Fact, "input15Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                    Assert.AreEqual(startValue + 12, input12Fact.Value, "another input12Fact value was expected");
                    Assert.AreEqual(startValue + 13, input13Fact.Value, "another input13Fact value was expected");
                    Assert.AreEqual(startValue + 14, input14Fact.Value, "another input14act value was expected");
                    Assert.AreEqual(startValue + 15, input15Fact.Value, "another input15Fact value was expected");
                });
        }

        [TestMethod]
        [TestCategory(TC.Objects.WantAction), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Request 16 facts.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void Want16FactsTestCase()
        {
            int startValue = 4;
            Input1Fact input1Fact = null;
            Input2Fact input2Fact = null;
            Input3Fact input3Fact = null;
            Input4Fact input4Fact = null;
            Input5Fact input5Fact = null;
            Input6Fact input6Fact = null;
            Input7Fact input7Fact = null;
            Input8Fact input8Fact = null;
            Input9Fact input9Fact = null;
            Input10Fact input10Fact = null;
            Input11Fact input11Fact = null;
            Input12Fact input12Fact = null;
            Input13Fact input13Fact = null;
            Input14Fact input14Fact = null;
            Input15Fact input15Fact = null;
            Input16Fact input16Fact = null;

            GivenCreateFactFactory()
                .And("Add rules", factory =>
                {
                    factory.Rules.Add(() => new Input1Fact(startValue + 1));
                    factory.Rules.Add((Input1Fact fact) => new Input2Fact(fact.Value + 1));
                    factory.Rules.Add((Input2Fact fact) => new Input3Fact(fact.Value + 1));
                    factory.Rules.Add((Input3Fact fact) => new Input4Fact(fact.Value + 1));
                    factory.Rules.Add((Input4Fact fact) => new Input5Fact(fact.Value + 1));
                    factory.Rules.Add((Input5Fact fact) => new Input6Fact(fact.Value + 1));
                    factory.Rules.Add((Input6Fact fact) => new Input7Fact(fact.Value + 1));
                    factory.Rules.Add((Input7Fact fact) => new Input8Fact(fact.Value + 1));
                    factory.Rules.Add((Input8Fact fact) => new Input9Fact(fact.Value + 1));
                    factory.Rules.Add((Input9Fact fact) => new Input10Fact(fact.Value + 1));
                    factory.Rules.Add((Input10Fact fact) => new Input11Fact(fact.Value + 1));
                    factory.Rules.Add((Input11Fact fact) => new Input12Fact(fact.Value + 1));
                    factory.Rules.Add((Input12Fact fact) => new Input13Fact(fact.Value + 1));
                    factory.Rules.Add((Input13Fact fact) => new Input14Fact(fact.Value + 1));
                    factory.Rules.Add((Input14Fact fact) => new Input15Fact(fact.Value + 1));
                    factory.Rules.Add((Input15Fact fact) => new Input16Fact(fact.Value + 1));
                })
                .And("Want 16 facts", factory =>
                {
                    factory.WantFact((Input1Fact fact1, Input2Fact fact2, Input3Fact fact3, Input4Fact fact4, Input5Fact fact5, Input6Fact fact6, Input7Fact fact7, Input8Fact fact8, Input9Fact fact9, Input10Fact fact10, Input11Fact fact11, Input12Fact fact12, Input13Fact fact13, Input14Fact fact14, Input15Fact fact15, Input16Fact fact16) =>
                        {
                            input1Fact = fact1;
                            input2Fact = fact2;
                            input3Fact = fact3;
                            input4Fact = fact4;
                            input5Fact = fact5;
                            input6Fact = fact6;
                            input7Fact = fact7;
                            input8Fact = fact8;
                            input9Fact = fact9;
                            input10Fact = fact10;
                            input11Fact = fact11;
                            input12Fact = fact12;
                            input13Fact = fact13;
                            input14Fact = fact14;
                            input15Fact = fact15;
                            input16Fact = fact16;
                        });
                })
                .When("Derive", factory => factory.Derive())
                .Then("Check result", _ =>
                {
                    Assert.IsNotNull(input1Fact, "input1Fact cannot be null");
                    Assert.IsNotNull(input2Fact, "input2Fact cannot be null");
                    Assert.IsNotNull(input3Fact, "input3Fact cannot be null");
                    Assert.IsNotNull(input4Fact, "input4Fact cannot be null");
                    Assert.IsNotNull(input5Fact, "input5Fact cannot be null");
                    Assert.IsNotNull(input6Fact, "input6Fact cannot be null");
                    Assert.IsNotNull(input7Fact, "input7Fact cannot be null");
                    Assert.IsNotNull(input8Fact, "input8Fact cannot be null");
                    Assert.IsNotNull(input9Fact, "input9Fact cannot be null");
                    Assert.IsNotNull(input10Fact, "input10Fact cannot be null");
                    Assert.IsNotNull(input11Fact, "input11Fact cannot be null");
                    Assert.IsNotNull(input12Fact, "input12Fact cannot be null");
                    Assert.IsNotNull(input13Fact, "input13Fact cannot be null");
                    Assert.IsNotNull(input14Fact, "input14Fact cannot be null");
                    Assert.IsNotNull(input15Fact, "input15Fact cannot be null");
                    Assert.IsNotNull(input16Fact, "input16Fact cannot be null");

                    Assert.AreEqual(startValue + 1, input1Fact.Value, "another input1Fact value was expected");
                    Assert.AreEqual(startValue + 2, input2Fact.Value, "another input2Fact value was expected");
                    Assert.AreEqual(startValue + 3, input3Fact.Value, "another input3Fact value was expected");
                    Assert.AreEqual(startValue + 4, input4Fact.Value, "another input4Fact value was expected");
                    Assert.AreEqual(startValue + 5, input5Fact.Value, "another input5Fact value was expected");
                    Assert.AreEqual(startValue + 6, input6Fact.Value, "another input6Fact value was expected");
                    Assert.AreEqual(startValue + 7, input7Fact.Value, "another input7Fact value was expected");
                    Assert.AreEqual(startValue + 8, input8Fact.Value, "another input8Fact value was expected");
                    Assert.AreEqual(startValue + 9, input9Fact.Value, "another input9Fact value was expected");
                    Assert.AreEqual(startValue + 10, input10Fact.Value, "another input10Fact value was expected");
                    Assert.AreEqual(startValue + 11, input11Fact.Value, "another input11Fact value was expected");
                    Assert.AreEqual(startValue + 12, input12Fact.Value, "another input12Fact value was expected");
                    Assert.AreEqual(startValue + 13, input13Fact.Value, "another input13Fact value was expected");
                    Assert.AreEqual(startValue + 14, input14Fact.Value, "another input14act value was expected");
                    Assert.AreEqual(startValue + 15, input15Fact.Value, "another input15Fact value was expected");
                    Assert.AreEqual(startValue + 16, input16Fact.Value, "another input16Fact value was expected");
                });
        }
    }
}
