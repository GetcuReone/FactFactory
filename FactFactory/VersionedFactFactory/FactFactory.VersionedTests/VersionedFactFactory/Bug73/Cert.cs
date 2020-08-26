using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class Cert : FactBase<Certificate>
    {
        public Cert(Certificate value) : base(value)
        {
        }
    }
}
