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
    /// <summary>
    /// Helper for test.
    /// </summary>
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

        /// <summary>
        /// Check for errors.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <param name="whenBlock">When block</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <returns>Result of checking.</returns>
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

        /// <summary>
        /// Check for errors.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <param name="thenBlock">Then block</param>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <returns>Result of checking.</returns>
        public static ThenBlock<InvalidDeriveOperationException, InvalidDeriveOperationException> AndAssertErrorDetail<TInput>(this ThenBlock<TInput, InvalidDeriveOperationException> thenBlock, string errorCode, string errorMessage)
        {
            return thenBlock.And($"Check error with code {errorCode}", error =>
            {
                if (error == null)
                    AssertErrorDetail(null, errorCode, errorMessage);
                else if (error.Details == null)
                    new FactFactoryException(null);

                new FactFactoryException(error.Details.Select(detail => (ErrorDetail)detail).ToList()).AssertErrorDetail(errorCode, errorMessage);
            });
        }

        /// <inheritdoc cref="ThenAssertErrorDetail{TInput}(WhenBlock{TInput, InvalidDeriveOperationException}, string, string)"/>
        public static ThenBlock<FactFactoryException, FactFactoryException> ThenAssertErrorDetail<TInput>(this WhenBlock<TInput, FactFactoryException> whenBlock, string errorCode, string errorMessage)
        {
            return whenBlock
                .ThenIsNotNull()
                .And($"Check error with code {errorCode}", error =>
                    error.AssertErrorDetail(errorCode, errorMessage));
        }

        /// <summary>
        /// Set param <see cref="FactParametersCodes.CalculateByRule"/>.
        /// </summary>
        /// <typeparam name="TFact">Fact type</typeparam>
        /// <param name="fact">Fact</param>
        /// <returns><paramref name="fact"/>.</returns>
        public static TFact SetCalculateByRuleParam<TFact>(this TFact fact)
            where TFact : IFact
        {
            fact.AddParameter(new FactParameter(FactParametersCodes.CalculateByRule, true));
            return fact;
        }

        /// <summary>
        /// Given block for add rules.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <typeparam name="TFactory">Fact factory type.</typeparam>
        /// <param name="givenBlock">Previous given block</param>
        /// <param name="factRules">Fact rules</param>
        /// <returns>Given block.</returns>
        public static GivenBlock<TFactory, TFactory> AndAddRules<TInput, TFactory>(this GivenBlock<TInput, TFactory> givenBlock, BaseFactRuleCollection factRules)
            where TFactory : BaseFactFactory<FactRuleCollection>
        {
            return givenBlock.And("Add rules", factory => factory.Rules.AddRange(factRules));
        }

        /// <summary>
        /// Then block for check <see cref="BaseFact{TFactValue}.Value"/>.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <typeparam name="TFact">Fact type</typeparam>
        /// <typeparam name="TFactValue">Fact value type.</typeparam>
        /// <param name="whenBlock">Previous when block</param>
        /// <param name="expectedValue">Expected value</param>
        /// <returns>Then block</returns>
        public static ThenBlock<TFact, TFact> ThenFactValueEquals<TInput, TFact, TFactValue>(this WhenBlock<TInput, TFact> whenBlock, TFactValue expectedValue)
            where TFact : BaseFact<TFactValue>
        {
            return whenBlock
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue,
                    errorMessage: $"A different meaning of the {typeof(TFact).Name} fact was expected", blockName: $"Check assert {typeof(TFact).Name} fact.");
        }

        /// <inheritdoc cref="ThenFactValueEquals{TInput, TFact, TFactValue}(WhenBlock{TInput, TFact}, TFactValue)"/>
        public static ThenBlock<TFact, TFact> ThenFactValueEquals<TInput, TFact, TFactValue>(this WhenAsyncBlock<TInput, TFact> whenBlock, TFactValue expectedValue)
            where TFact : BaseFact<TFactValue>
        {
            return whenBlock
                .ThenIsNotNull()
                .AndAreEqual(fact => fact.Value, expectedValue,
                    errorMessage: $"A different meaning of the {typeof(TFact).Name} fact was expected", blockName: $"Check assert {typeof(TFact).Name} fact.");
        }
    }
}
