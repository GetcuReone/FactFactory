using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Extensions
{
    /// <summary>
    /// Extensions methods for array of <see cref="IFact"/>
    /// </summary>
    public static class ArrayOfFactExtensions
    {
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
    }
}
