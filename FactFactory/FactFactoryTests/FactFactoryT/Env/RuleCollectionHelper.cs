using FactFactoryTests.CommonFacts;

namespace FactFactoryTests.FactFactoryT.Env
{
    public static class RuleCollectionHelper
    {
        public static FactFactory.Entities.FactRuleCollection GetInputFactRules()
        {
            return new FactFactory.Entities.FactRuleCollection
            {
                (Input15Fact firstFact, Input14Fact secondFact) => new Input16Fact(firstFact.Value + secondFact.Value - 3),
                (Input2Fact secondFact) => new Input14Fact(secondFact.Value + 14),
                (Input1Fact firstFact, Input2Fact secondFact) => new Input15Fact(firstFact.Value + secondFact.Value),
                () => new Input1Fact(1),
                (Input1Fact fact) => new Input2Fact(fact.Value * 2),
                (Input2Fact firstFact, Input3Fact secondFact) => new Input4Fact(firstFact.Value + secondFact.Value),
                (Input2Fact firstFact, Input5Fact secondFact) => new Input4Fact(firstFact.Value + secondFact.Value),
                (Input4Fact secondFact) => new Input6Fact(secondFact.Value + 14),
                (Input5Fact secondFact) => new Input6Fact(secondFact.Value + 14),
                (Input6Fact fact) => new Input7Fact(fact.Value * 2),
            };
        }

        public static FactFactory.Entities.FactRuleCollection GetRulesForNotAvailableInput6Fact()
        {
            return new FactFactory.Entities.FactRuleCollection
            {
                (Input15Fact firstFact, Input14Fact secondFact) => new Input16Fact(firstFact.Value + secondFact.Value - 3),
                (Input2Fact secondFact) => new Input14Fact(secondFact.Value + 14),
                (Input1Fact firstFact, Input2Fact secondFact) => new Input15Fact(firstFact.Value + secondFact.Value),
                () => new Input1Fact(1),
                (Input1Fact fact) => new Input2Fact(fact.Value * 2),
                (Input2Fact firstFact, Input3Fact secondFact) => new Input4Fact(firstFact.Value + secondFact.Value),
                (Input2Fact firstFact, Input5Fact secondFact) => new Input4Fact(firstFact.Value + secondFact.Value),
                (Input4Fact secondFact) => new Input6Fact(secondFact.Value + 14),
            };
        }
    }
}
