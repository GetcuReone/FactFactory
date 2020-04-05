using System;

namespace FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities
{
    public sealed class Certificate
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActivate { get; set; }

        public int ValidityDay { get; set; }

        public DateTime ActivateDate { get; set; }

        public Guid CertificateCode { get; set; }

        public long HashCode { get; set; }
    }
}
