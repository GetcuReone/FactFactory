using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;

namespace FactFactoryTests.CommonFacts
{
    internal class SpecialFact : SpecialFactBase
    {
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return GetFactType().EqualsFactType(specialFact.GetFactType());
        }
    }
}
