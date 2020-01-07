using FactFactoryTests.CommonFacts;

namespace FactFactoryTests.FactFactoryT
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
            };
        }
    }
}
