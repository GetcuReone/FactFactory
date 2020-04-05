using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert_Validation : VersionedFactBase<Certificate>
    {
        public Cert_Validation(Certificate value) : base(value)
        {
        }
    }
}
