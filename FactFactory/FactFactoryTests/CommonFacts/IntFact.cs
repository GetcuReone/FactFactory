using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class IntFact : FactBase<int>
    {
        public IntFact(int fact) : base(fact)
        {
        }

        public override IFactInfo GetFactInfo()
        {
            return new FactInfo<IntFact>();
        }
    }
}
