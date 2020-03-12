using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.CommonFacts
{
    internal sealed class Fact2 : VersionedFactBase<int>
    {
        public Fact2(int fact) : base(fact)
        {
        }
    }
}
