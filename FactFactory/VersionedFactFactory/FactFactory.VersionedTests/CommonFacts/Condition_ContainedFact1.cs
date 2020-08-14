using GetcuReone.FactFactory.BaseEntities.SpecialFacts;

namespace FactFactory.VersionedTests.CommonFacts
{
    internal sealed class Condition_ContainedFact1 : ConditionFactBase<Fact1>
    {
        public override bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return container.Contains<Fact1>();
        }
    }
}
