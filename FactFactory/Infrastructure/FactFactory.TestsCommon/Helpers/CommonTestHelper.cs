using GetcuReone.FactFactory;
using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.GwtTestFramework.Entities;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FactFactory.TestsCommon.Helpers
{
    public static class CommonTestHelper
    {
        private static void AssertErrorDetail(this FactFactoryExceptionBase<ErrorDetail> error, string errorCode, string errorMessage)
        {
            Assert.IsNotNull(error, "error cannot be null");
            Assert.IsNotNull(error.Details, "error cannot be null");
            Assert.AreNotEqual(0, error.Details.Count, "Details must contain 0 detail");

            if (!error.Details.Any(detail => detail.Code == errorCode && detail.Reason == errorMessage))
                Assert.Fail($"Expected '{errorCode}' code and reason '{errorMessage}'.");
        }

        public static ThenBlock<InvalidDeriveOperationException, InvalidDeriveOperationException> ThenAssertErrorDetail<TInput>(this WhenBlock<TInput, InvalidDeriveOperationException> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock
                .Then($"Check error with code {errorCode}", error =>
                {
                    if (error == null)
                        AssertErrorDetail(null, errorCode, errorMessage);
                    else if (error.Details == null)
                        new FactFactoryException(null);

                    new FactFactoryException(error.Details.Select(detail => (ErrorDetail)detail).ToList()).AssertErrorDetail(errorCode, errorMessage);
                });
        }

        public static ThenBlock<InvalidDeriveOperationException, InvalidDeriveOperationException> AndAssertErrorDetail<TInput>(this ThenBlock<TInput, InvalidDeriveOperationException> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock.And($"Check error with code {errorCode}", error =>
            {
                if (error == null)
                    AssertErrorDetail(null, errorCode, errorMessage);
                else if (error.Details == null)
                    new FactFactoryException(null);

                new FactFactoryException(error.Details.Select(detail => (ErrorDetail)detail).ToList()).AssertErrorDetail(errorCode, errorMessage);
            });
        }

        public static ThenBlock<FactFactoryException, FactFactoryException> ThenAssertErrorDetail<TInput>(this WhenBlock<TInput, FactFactoryException> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock
                .ThenIsNotNull()
                .And($"Check error with code {errorCode}", error =>
                    error.AssertErrorDetail(errorCode, errorMessage));
        }

        public static TFact SetCalculateByRuleParam<TFact>(this TFact fact)
            where TFact : IFact
        {
            fact.AddParameter(new FactParameter(FactParametersCodes.CalculateByRule, true));
            return fact;
        }

        public static GivenBlock<TFactory, TFactory> AndAddRules<TInput, TFactory>(this GivenBlock<TInput, TFactory> givenBlock, FactRuleCollectionBase<FactRule> factRules)
            where TFactory : FactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }

        public static ThenBlock<TFact, TFact> ThenFactValueEquals<TInput, TFact, TFactValue>(this WhenBlock<TInput, TFact> whenBlock, TFactValue expectedValue)
            where TFact : FactBase<TFactValue>
        {
            return whenBlock
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue,
                    errorMessage: $"A different meaning of the {typeof(TFact).Name} fact was expected", blockName: $"Check assert {typeof(TFact).Name} fact.");
        }
    }
}
