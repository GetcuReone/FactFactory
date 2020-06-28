using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Helpers
{
    /// <summary>
    /// Helper for <see cref="FactFactoryBase{TFact, TFactContainer, TFactRule, TFactRuleCollection, TWantAction}"/>
    /// </summary>
    public static class FactFactoryHelper
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

        internal static void VerifyRecursive<TRuntimeSpecialFact, TFactBase, TFactRule>(this TRuntimeSpecialFact runtimeSpecialFact, TFactRule factRule)
            where TRuntimeSpecialFact : IRuntimeSpecialFact
            where TFactBase : IFact
            where TFactRule : IFactRule<TFactBase>
        {
            if (runtimeSpecialFact.FactType.Compare(factRule.OutputFactType))
                throw CreateDeriveException<TFactBase>(ErrorCode.FactCannotDerived, $"Rule of fact is recursive. Rule: <{factRule}>.");
        }

        internal static InvalidDeriveOperationException<TFact> CreateDeriveException<TFact>(List<KeyValuePair<string, string>> codeReasonPairs, IWantAction<TFact> requiredAction)
            where TFact : IFact
        {
            return new InvalidDeriveOperationException<TFact>(codeReasonPairs
                .Select(
                    pair => new DeriveErrorDetail<TFact>(pair.Key, pair.Value, requiredAction, null))
                .ToList().ToReadOnlyCollection());
        }

        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        internal static bool ContainsContainer<TFact>(this IFactType factType, IFactContainer<TFact> container)
            where TFact : IFact
        {
            return factType.TryGetFact(container, out TFact _);
        }

        internal static void CheckArgumentFacts<TFact>(this IEnumerable<IFactType> factTypes)
            where TFact : IFact
        {
            var invalidTypes = factTypes.Where(type => !type.IsFactType<TFact>()).ToList();

            if (!invalidTypes.IsNullOrEmpty())
                throw new ArgumentException($"{string.Join(", ", invalidTypes.ConvertAll(type => type.FactName))} types are not inherited from {typeof(TFact).FullName}");
        }

        internal static TFact ConvertFact<TFact>(this IFact fact)
            where TFact : IFact
        {
            if (fact is TFact fact1)
                return fact1;

            throw CreateDeriveException<TFact>(ErrorCode.InvalidFactType, $"Type {fact.GetFactType().FactName} cannot be converted {typeof(TFact).Name}");
        }

        internal static IgnoreReadOnlySpace<TFact> CreateIgnoreReadOnlySpace<TFact>(this FactContainerBase<TFact> container)
            where TFact : IFact
        {
            return new IgnoreReadOnlySpace<TFact>(container);
        }

        internal static IFactType CannotIsType<TFact>(this IFactType type, string paramName)
            where TFact : IFact
        {
            if (type.IsFactType<TFact>())
                throw new ArgumentException($"Parameter {paramName} should not be converted into {typeof(TFact).FullName}");

            return type;
        }

        internal static void CheckSpecialFactType(this IFactType type)
        {
            if (type.IsFactType<ISpecialFact>())
            {
                var specialResult = new bool[]
                {
                    type.IsFactType<INotContainedFact>(),
                    type.IsFactType<IContainedFact>(),
                    type.IsFactType<ICannotDerivedFact>(),
                };

                if (specialResult.Count(result => result == true) > 1)
                {
                    throw CreateException(ErrorCode.InvalidFactType, $"{type.FactName} implements more than one special fact interface");
                }
            }
        }
    }
}
