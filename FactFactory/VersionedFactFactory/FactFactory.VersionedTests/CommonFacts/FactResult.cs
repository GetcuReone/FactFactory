using GetcuReone.FactFactory.Versioned;
using GetcuReone.FactFactory.Versioned.Interfaces;

namespace FactFactory.VersionedTests.CommonFacts
{
    public sealed class FactResult : VersionedFactBase<long>
    {
        public FactResult(long fact) : base(fact)
        {
        }

        public FactResult(long value, IVersionFact version) : base(value, version)
        {
        }
    }
}
