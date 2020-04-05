using GetcuReone.FactFactory.Versioned;
using System.IO;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFileInfo_Validation : VersionedFactBase<FileInfo>
    {
        public CertFileInfo_Validation(FileInfo value) : base(value)
        {
        }
    }
}
