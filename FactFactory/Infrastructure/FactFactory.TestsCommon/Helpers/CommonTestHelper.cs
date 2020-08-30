﻿using GetcuReone.FactFactory;
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

        public static ThenBlock<InvalidDeriveOperationException> ThenAssertErrorDetail(this WhenBlock<InvalidDeriveOperationException> whenBlock, string errorCode, string errorMessage)
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

        public static ThenBlock<InvalidDeriveOperationException> AndAssertErrorDetail(this ThenBlock<InvalidDeriveOperationException> whenBlock, string errorCode, string errorMessage)
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

        public static ThenBlock<FactFactoryException> ThenAssertErrorDetail(this WhenBlock<FactFactoryException> whenBlock, string errorCode, string errorMessage)
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

        public static GivenBlock<TFactory> AndAddRules<TFactory>(this GivenBlock<TFactory> givenBlock, FactRuleCollectionBase<FactRule> factRules)
            where TFactory : FactFactoryBase<FactRule, FactRuleCollection, WantAction, FactContainer>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }
    }
}
