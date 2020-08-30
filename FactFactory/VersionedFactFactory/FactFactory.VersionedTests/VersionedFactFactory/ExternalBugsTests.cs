using FactFactory.TestsCommon;
using FactFactory.VersionedTests.CommonFacts;
using FactFactory.VersionedTests.VersionedFactFactory.Bug73;
using FactFactory.VersionedTests.VersionedFactFactory.Bug73.Entities;
using FactFactory.VersionedTests.VersionedFactFactory.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Collection = GetcuReone.FactFactory.Entities.FactRuleCollection;
using Container = GetcuReone.FactFactory.Versioned.Entities.VersionedFactContainer;

namespace FactFactory.VersionedTests.VersionedFactFactory
{
    [TestClass]
    public sealed class ExternalBugsTests : VersionedFactFactoryTestBase
    {
        [TestMethod]
        [TestCategory(TC.Projects.Versioned), TestCategory(TC.Objects.Factory), TestCategory(GetcuReoneTC.Unit)]
        [Description("Remove the node from the tree when necessary (test for bug 73).")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void RemoveNodeFromTreeWhenNecessaryTestCase()
        {
            var certificate = new Certificate();
            var container = new Container
            {
                new CertFileInfo(default),
                new CryptKey("key"),
            };

            GivenCreateVersionedFactFactory(new List<IVersionFact>
            {
                new Version1(),
            })
                .AndAddRules(new Collection
                {
                    (Version1 v, NeedEncrypt n, Cert certFact) => new DecryptedText(""),
                    (Version1 v, DecryptedText text, CryptKey key) => new EncryptedText(""),
                    (Version1 v, CanCalculateDefaultKey c, CertFileInfo fileInfoFact) => new CryptKey(""),
                    (Version1 v, CertFileInfo fileInfo) => new EncryptedText(""),
                    (Version1 v, EncryptedText text, CryptKey key) => new DecryptedText(""),
                    (Version1 v, DecryptedText text) => new Cert_Validation(certificate)
                })
                .AndAddRules(new Collection
                {
                    (Version1 version, CertFileInfo_Validation fileInfo) => new CertFileInfo(fileInfo.Value),
                    (Version1 v, CertFilePath_Validation filePath) => new CertFileInfo_Validation(null),
                    (Version1 v, Cert_ValidationNotNull cert) => new Cert_HashCode(0),
                    (Version1 v, Cert_ValidationNotNull cert, Cert_HashCode hashCode) => new Cert(cert.Value),
                    (Version1 v, Cert_Validation cert) => new Cert_ValidationNotNull(cert.Value),
                })
                .When("Derive fact.", factory => factory.DeriveFact<Cert, Version1>(container))
                .ThenAreEqual(fact => fact.Value, certificate);
        }
    }
}
