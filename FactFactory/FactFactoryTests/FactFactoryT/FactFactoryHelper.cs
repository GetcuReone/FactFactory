using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WAction = GetcuReone.FactFactory.Entities.WantAction;

namespace FactFactoryTests.FactFactoryT
{
    internal static class FactFactoryHelper
    {
        internal static GivenBlock<GetcuReone.FactFactory.FactFactory> AndRulesNotNul(this GivenBlock<GetcuReone.FactFactory.FactFactory> givenBlock)
        {
            return givenBlock.And("Rules not null", factory =>
            {
                Assert.IsNotNull(factory.Rules, "Rules cannot be null");
                return factory;
            });
        }

        internal static ThenBlock<InvalidDeriveOperationException<FactBase, WAction>> ThenAssertErrorDetail(this WhenBlock<InvalidDeriveOperationException<FactBase, WAction>> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock.Then("Check error", error =>
            {
                Assert.IsNotNull(error, "error cannot be null");
                Assert.IsNotNull(error.Details, "error cannot be null");
                Assert.AreNotEqual(0, error.Details.Count, "Details must contain 0 detail");

                ErrorDetail detail = error.Details.FirstOrDefault(d => d.Code == errorCode);

                if (detail == null)
                    Assert.Fail($"Expected {errorCode} code.");
                Assert.AreEqual(errorMessage, detail.Reason, "Expected another reason");
            });
        }
    }
}
