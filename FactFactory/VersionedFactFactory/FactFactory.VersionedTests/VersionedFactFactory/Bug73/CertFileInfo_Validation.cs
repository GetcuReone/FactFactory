using GetcuReone.FactFactory;
using System.IO;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73
{
    internal sealed class CertFileInfo_Validation : FactBase<FileInfo>
    {
        public CertFileInfo_Validation(FileInfo value) : base(value)
        {
        }
    }
}
