using GetcuReone.FactFactory.Versioned;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFilePath_Validation : VersionedFactBase<string>
    {
        public CertFilePath_Validation(string value) : base(value)
        {
        }
    }
}
