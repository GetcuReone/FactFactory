using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_HashCode : VersionedFactBase<long>
    {
        public Cert_HashCode(long value) : base(value)
        {
        }
    }
}
