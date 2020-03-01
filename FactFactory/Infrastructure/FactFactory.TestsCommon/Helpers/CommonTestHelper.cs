using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using GivenWhenThen.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GetcuReone.FactFactory;

namespace FactFactory.TestsCommon.Helpers
{
    public static class CommonTestHelper
    {
        private static void AssertErrorDetail(this FactFactoryExceptionBase<ErrorDetail> error, string errorCode, string errorMessage)
        {
            Assert.IsNotNull(error, "error cannot be null");
            Assert.IsNotNull(error.Details, "error cannot be null");
            Assert.AreNotEqual(0, error.Details.Count, "Details must contain 0 detail");

            ErrorDetail detail = error.Details.FirstOrDefault(d => d.Code == errorCode);

            if (detail == null)
                Assert.Fail($"Expected {errorCode} code.");
            Assert.AreEqual(errorMessage, detail.Reason, "Expected another reason");
        }

        public static ThenBlock<InvalidDeriveOperationException<TFact, TAction>> ThenAssertErrorDetail<TFact, TAction>(this WhenBlock<InvalidDeriveOperationException<TFact, TAction>> whenBlock, string errorCode, string errorMessage)
            where TFact : IFact
            where TAction : IWantAction<TFact>
        {
            return whenBlock.Then($"Check error with code {errorCode}", error =>
            {
                if (error == null)
                    AssertErrorDetail(null, errorCode, errorMessage);
                else if (error.Details == null)
                    new FactFactoryException(null);

                new FactFactoryException(error.Details.Select(detail => (ErrorDetail)detail).ToList()).AssertErrorDetail(errorCode, errorMessage);
            });
        }

        public static ThenBlock<FactFactoryException> ThenAssertErrorDetail(this WhenBlock<FactFactoryException> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock.Then($"Check error with code {errorCode}", error => error.AssertErrorDetail(errorCode, errorMessage));
        }
    }
}
