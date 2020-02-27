using GetcuReone.FactFactory.Versioned.Facts;

namespace FactFactory.VersionedTests.CommonFacts
{
    public sealed class FactResult : VersionedFactBase<long>
    {
        public FactResult(long fact) : base(fact)
        {
        }
    }
}
