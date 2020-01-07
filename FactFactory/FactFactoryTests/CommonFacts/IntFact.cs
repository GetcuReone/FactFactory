using FactFactory.Entities;
using FactFactory.Facts;
using FactFactory.Interfaces;

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
