using FactFactoryTests.CommonFacts;
using GetcuReone.FactFactory.BaseEntities.SpecialFacts;

namespace FactFactory.DefaultTests.CommonFacts
{
    internal sealed class Condition_ContainedOtherFact : ConditionFactBase<OtherFact>
    {
        public override bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            return container.Contains<OtherFact>();
        }
    }
}
