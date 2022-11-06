using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_HashCode : BaseFact<long>
    {
        public Cert_HashCode(long value) : base(value) { }
    }
}
