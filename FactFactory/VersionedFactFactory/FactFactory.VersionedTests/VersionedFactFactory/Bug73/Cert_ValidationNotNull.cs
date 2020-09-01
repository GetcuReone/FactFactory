using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_ValidationNotNull : FactBase<Certificate>
    {
        public Cert_ValidationNotNull(Certificate value) : base(value)
        {
        }
    }
}
