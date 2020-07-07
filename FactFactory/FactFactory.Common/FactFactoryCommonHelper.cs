using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Common helper for FactFactory.
    /// </summary>
    public static class FactFactoryCommonHelper
    {
        /// <summary>
        /// True - <paramref name="items"/> is null or empty
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> items)
        {
            return items == null || !items.Any();
        }

        /// <summary>
        /// Convert list to <see cref="ReadOnlyCollection{TItem}"/>
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<TItem> ToReadOnlyCollection<TItem>(this IList<TItem> items)
        {
            return new ReadOnlyCollection<TItem>(items);
        }

        /// <summary>
        /// Create <see cref="FactFactoryException"/>
        /// </summary>
        /// <param name="code">error code</param>
        /// <param name="reason">error reason</param>
        /// <returns></returns>
        public static FactFactoryException CreateException(string code, string reason)
        {
            return new FactFactoryException(
                new List<ErrorDetail>
                {
                    new ErrorDetail(code, reason)
                }.ToReadOnlyCollection());
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException{TFact}"/>.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="details"></param>
        /// <returns></returns>
        public static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(IReadOnlyCollection<DeriveErrorDetail<TFact>> details)
            where TFact : IFact
        {
            return new InvalidDeriveOperationException<TFact>(details);
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException{TFact}"/>.
        /// </summary>
        /// <typeparam name="TFact">Base class for facts.</typeparam>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <returns></returns>
        public static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(string code, string reason)
            where TFact : IFact
        {
            return CreateDeriveException(code, reason, (IWantAction<TFact>)null);
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException{TFact}"/>.
        /// </summary>
        /// <typeparam name="TFact">Base class for facts.</typeparam>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <returns></returns>
        public static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(string code, string reason, IWantAction<TFact> requiredAction)
            where TFact : IFact
        {
            return CreateDeriveException(code, reason, requiredAction, null);
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException{TFact}"/>.
        /// </summary>
        /// <typeparam name="TFact">Base class for facts.</typeparam>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="requiredFacts">The facts that tried to derive.</param>
        /// <returns></returns>
        public static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(string code, string reason, IWantAction<TFact> requiredAction, IReadOnlyCollection<DeriveFactErrorDetail> requiredFacts)
            where TFact : IFact
        {
            return new InvalidDeriveOperationException<TFact>(new List<DeriveErrorDetail<TFact>>
            {
                new DeriveErrorDetail<TFact>(code, reason, requiredAction, requiredFacts),
            }.ToReadOnlyCollection());
        }

        /// <summary>
        /// Check type of fact.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <param name="fact"></param>
        public static void ValidateTypeOfFact<TFactBase>(this IFact fact) where TFactBase : IFact
        {
            switch (fact)
            {
                case TFactBase _:
                case ISpecialFact _:
                    break;

                default: throw CreateException(ErrorCode.InvalidData, $"The fact must be inherited either from the base type or from {nameof(ISpecialFact)}. Fact:<{fact}>.");
            }
        }

        /// <summary>
        /// Is the fact type valid.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <param name="factType"></param>
        /// <returns></returns>
        public static bool IsValidFactType<TFactBase>(this IFactType factType)
            where TFactBase : IFact
        {
            return factType.IsFactType<TFactBase>() || factType.IsFactType<ISpecialFact>();
        }

        /// <summary>
        /// Cannot is <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="type"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static IFactType CannotIsType<TFact>(this IFactType type, string paramName)
            where TFact : IFact
        {
            if (type.IsFactType<TFact>())
                throw new ArgumentException($"Parameter {paramName} should not be converted into {typeof(TFact).FullName}");

            return type;
        }

        /// <summary>
        /// Type checking facts.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <param name="factTypes"></param>
        public static void VerifyFactTypes<TFactBase>(this IEnumerable<IFactType> factTypes)
            where TFactBase : IFact
        {
            var invalidTypes = factTypes
                .Where(type => !type.IsValidFactType<TFactBase>())
                .ToList();

            if (!invalidTypes.IsNullOrEmpty())
                throw new ArgumentException($"{string.Join(", ", invalidTypes.ConvertAll(type => type.FactName))} types are not inherited from {typeof(TFactBase).FullName}.");
        }

        /// <summary>
        /// Validation of the fact of the condition.
        /// </summary>
        /// <param name="type"></param>
        public static void ValidateConditionFact(this IFactType type)
        {
            if (type.IsFactType<ISpecialFact>())
            {
                var specialResult = new bool[]
                {
                    type.IsFactType<ICannotDerivedFact>(),
                    type.IsFactType<ICanDerivedFact>(),
                };

                if (specialResult.Count(result => result == true) > 1)
                    throw CreateException(ErrorCode.InvalidFactType, $"{type.FactName} implements more than one runtime special fact interface.");
            }
        }
    }
}
