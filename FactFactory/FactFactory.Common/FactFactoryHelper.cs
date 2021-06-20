using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
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
    public static class FactFactoryHelper
    {
        /// <summary>
        /// True - <paramref name="items"/> is null or empty
        /// </summary>
        /// <typeparam name="TItem">Type items.</typeparam>
        /// <param name="items">Collection.</param>
        /// <returns><paramref name="items"/> is empty or null?</returns>
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> items)
        {
            return items == null || !items.Any();
        }

        /// <summary>
        /// Convert list to <see cref="ReadOnlyCollection{TItem}"/>
        /// </summary>
        /// <typeparam name="TItem">Type item.</typeparam>
        /// <param name="items">Coollection.</param>
        /// <returns>Read-only collection.</returns>
        public static ReadOnlyCollection<TItem> ToReadOnlyCollection<TItem>(this IList<TItem> items)
        {
            return new ReadOnlyCollection<TItem>(items);
        }

        /// <summary>
        /// Create <see cref="FactFactoryException"/>
        /// </summary>
        /// <param name="code">error code</param>
        /// <param name="reason">error reason</param>
        /// <returns>Exception.</returns>
        public static FactFactoryException CreateException(string code, string reason)
        {
            return new FactFactoryException(
                new List<ErrorDetail>
                {
                    new ErrorDetail(code, reason)
                }.ToReadOnlyCollection());
        }

        /// <summary>
        /// Create <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="details">Error deteils.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(IReadOnlyCollection<DeriveErrorDetail> details)
        {
            return new InvalidDeriveOperationException(details);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason)
        {
            return CreateDeriveException(code, reason, null, null);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="container">Fact container.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason, IWantAction requiredAction, IFactContainer container)
        {
            return CreateDeriveException(code, reason, requiredAction , container, null);
        }

        /// <summary>
        /// Creates <see cref="InvalidDeriveOperationException"/>.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        /// <param name="requiredAction">Action for which it was not possible to derive the facts.</param>
        /// <param name="container">Fact container.</param>
        /// <param name="requiredFacts">The facts that tried to derive.</param>
        /// <returns>Exception.</returns>
        public static InvalidDeriveOperationException CreateDeriveException(string code, string reason, IWantAction requiredAction, IFactContainer container, IReadOnlyCollection<DeriveFactErrorDetail> requiredFacts)
        {
            return new InvalidDeriveOperationException(new List<DeriveErrorDetail>
            {
                new DeriveErrorDetail(code, reason, requiredAction, container, requiredFacts),
            }.ToReadOnlyCollection());
        }

        /// <summary>
        /// Cannot is <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact">Type fact.</typeparam>
        /// <param name="type">Type fact info.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <returns><paramref name="type"/>.</returns>
        public static IFactType CannotIsType<TFact>(this IFactType type, string paramName)
            where TFact : IFact
        {
            if (type.IsFactType<TFact>())
                throw new ArgumentException($"Parameter {paramName} should not be converted into {typeof(TFact).FullName}");

            return type;
        }

        /// <summary>
        /// Was the fact calculated using the rule.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="fact"></param>
        /// <returns></returns>
        public static bool IsCalculatedByRule<TFact>(this TFact fact)
            where TFact : IFact
        {
            object value = fact.GetParameter(FactParametersCodes.CalculateByRule)?.Value;

            if (value == null)
                return false;
            if (value is bool valueBool)
                return valueBool;

            return false;
        }

        /// <summary>
        /// Returns first fact by type <typeparamref name="TFact"/>.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="facts"></param>
        /// <returns></returns>
        public static TFact GetFact<TFact>(this IEnumerable<IFact> facts)
            where TFact : IFact
        {
            return (TFact)facts.First(fact => fact is TFact);
        }

        /// <summary>
        /// Compare fact rules.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareTo<TFactRule>(this TFactRule x, TFactRule y)
            where TFactRule : IFactRule
        {
            if ((x is IWantAction) || (y is IWantAction))
                return 0;

            if (x.InputFactTypes.IsNullOrEmpty())
            {
                if (y.InputFactTypes.IsNullOrEmpty())
                    return 0;

                return y.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? -1
                    : 1;
            }

            if (y.InputFactTypes.IsNullOrEmpty())
            {
                return x.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? 1
                    : -1;
            }

            int xCountCondition = x.InputFactTypes.Count(factType => factType.IsFactType<IBuildConditionFact>());
            int yCountCondition = y.InputFactTypes.Count(factType => factType.IsFactType<IBuildConditionFact>());

            if (xCountCondition != yCountCondition)
            {
                return xCountCondition > yCountCondition
                    ? 1
                    : -1;
            }

            int xCountSpecial = x.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());
            int yCountSpecial = y.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());

            if (xCountSpecial != yCountSpecial)
            {
                return xCountSpecial > yCountSpecial
                    ? 1
                    : -1;
            }

            if (x.InputFactTypes.Count > y.InputFactTypes.Count)
                return -1;
            if (x.InputFactTypes.Count < y.InputFactTypes.Count)
                return 1;
            return 0;
        }

        /// <summary>
        /// The first fact of the same type.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="facts">Fact list.</param>
        /// <param name="factType">Fact type.</param>
        /// <param name="cache">Cache.</param>
        /// <returns>Fact or null.</returns>
        public static TFact FirstFactByFactType<TFact>(this IEnumerable<TFact> facts, IFactType factType, IFactTypeCache cache)
            where TFact : IFact
        {
            return facts.FirstOrDefault(fact => cache.GetFactType(fact).EqualsFactType(factType));
        }

        /// <summary>
        /// Compare facts by <see cref="FactParametersCodes.CalculateByRule"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareTo(this IFact x, IFact y)
        {
            if (x.IsCalculatedByRule())
            {
                if (!y.IsCalculatedByRule())
                    return -1;
            }
            else if (y.IsCalculatedByRule())
                return 1;

            return 0;
        }

        /// <summary>
        /// Get an array of facts of a specific type.
        /// </summary>
        /// <param name="facts">Facts.</param>
        /// <param name="factType">Required type.</param>
        /// <param name="cache">Cache (optional).</param>
        /// <returns></returns>
        public static IEnumerable<IFact> WhereFactsByFactType(this IEnumerable<IFact> facts, IFactType factType, IFactTypeCache cache)
        {
            Func<IFact, IFactType> getFactTypeFunc;
            if (cache != null)
                getFactTypeFunc = cache.GetFactType;
            else
                getFactTypeFunc = fact => fact.GetFactType();

            return facts.Where(fact => getFactTypeFunc(fact).EqualsFactType(factType));
        }

        /// <summary>
        /// Get an array of facts of a specific types.
        /// </summary>
        /// <param name="facts">Facts.</param>
        /// <param name="factTypes">Required types.</param>
        /// <param name="cache">Cache (optional).</param>
        /// <returns></returns>
        public static IEnumerable<IFact> WhereFactsByFactTypes(this IEnumerable<IFact> facts, IEnumerable<IFactType> factTypes, IFactTypeCache cache)
        {
            Func<IFact, IFactType> getFactTypeFunc;
            if (cache != null)
                getFactTypeFunc = cache.GetFactType;
            else
                getFactTypeFunc = fact => fact.GetFactType();

            return facts.Where(fact => 
            {
                var factType = getFactTypeFunc(fact);
                return factTypes.Any(type => type.EqualsFactType(factType));
            });
        }
    }
}
