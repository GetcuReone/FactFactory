using GetcuReone.FactFactory.Versioned.Facts;

namespace FactFactory.VersionedTests.CommonFacts
{
    public sealed class FactResult : VersionedFactBase<int>
    {
        public FactResult(int fact) : base(fact)
        {
        }
    }
}
