using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Versioned.Facts;

namespace FactFactory.VersionedTests.CommonFacts
{
    public sealed class Fact1 : VersionedFactBase<int>
    {
        public Fact1(int fact) : base(fact)
        {
        }
    }
}
