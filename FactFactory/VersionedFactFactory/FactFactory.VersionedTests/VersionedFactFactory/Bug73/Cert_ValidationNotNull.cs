using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_ValidationNotNull : VersionedFactBase<Certificate>
    {
        public Cert_ValidationNotNull(Certificate value) : base(value)
        {
        }
    }
}
