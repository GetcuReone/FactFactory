using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
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
                });
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException{TFact, TWantAction}"/>
        /// </summary>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static InvalidDeriveOperationException<TFact, TWantAction> CreateDeriveException<TFact, TWantAction>(string code, string reason)
            where TFact : IFact
            where TWantAction : IWantAction<TFact>
        {
            return new InvalidDeriveOperationException<TFact, TWantAction>(
                new List<DeriveErrorDetail<TFact, TWantAction>>
                {
                    new DeriveErrorDetail<TFact, TWantAction>(code, reason, default, null)
                });
        }

        internal static InvalidDeriveOperationException<TFact, TWantAction> CreateDeriveException<TFact, TWantAction>(Dictionary<TWantAction, Dictionary<IFactType, List<List<IFactType>>>> notFoundFacts)
            where TFact : IFact
            where TWantAction : IWantAction<TFact>
        {
            List<DeriveErrorDetail<TFact, TWantAction>> details = new List<DeriveErrorDetail<TFact, TWantAction>>();

            foreach(var keyAction in notFoundFacts.Keys)
            {
                details.Add(new DeriveErrorDetail<TFact, TWantAction>(
                    ErrorCode.FactCannotCalculated,
                    $"facts {string.Join(", ", notFoundFacts[keyAction].Keys.Select(k => k.FactName))} cannot be calculated for action {keyAction.ToString()}",
                    keyAction,
                    notFoundFacts[keyAction]));
            }

            return new InvalidDeriveOperationException<TFact, TWantAction>(details);
        }

        internal static IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        internal static bool ContainsContainer<TFact, TFactContainer>(this IFactType factType, TFactContainer container)
            where TFact : IFact
            where TFactContainer : IFactContainer<TFact>
        {
            return factType.TryGetFact(container, out TFact _);//container.Any(fact => fact.GetFactType().Compare(factType));
        }

        internal static void CheckArgumentFacts<TFact>(this IEnumerable<IFactType> factTypes)
            where TFact : IFact
        {
            var invalidTypes = factTypes.Where(type => !type.IsFactType<TFact>()).ToList();

            if (!invalidTypes.IsNullOrEmpty())
                throw new ArgumentException($"{string.Join(", ", invalidTypes.ConvertAll(type => type.FactName))} types are not inherited from {typeof(TFact).FullName}");
        }
    }
}
