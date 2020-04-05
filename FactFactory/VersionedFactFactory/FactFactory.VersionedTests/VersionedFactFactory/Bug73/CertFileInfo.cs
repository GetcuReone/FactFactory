using GetcuReone.FactFactory.Versioned;
using System.IO;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFileInfo : VersionedFactBase<FileInfo>
    {
        public CertFileInfo(FileInfo value) : base(value)
        {
        }
    }
}
