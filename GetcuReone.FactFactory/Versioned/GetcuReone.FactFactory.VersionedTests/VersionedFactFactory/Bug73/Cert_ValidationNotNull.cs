using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_ValidationNotNull : BaseFact<Certificate>
    {
        public Cert_ValidationNotNull(Certificate value) : base(value) { }
    }
}
