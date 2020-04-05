using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert : VersionedFactBase<Certificate>
    {
        public Cert(Certificate value) : base(value)
        {
        }
    }
}
