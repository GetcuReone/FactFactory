using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Contains fact type information.
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public abstract class FactTypeBase<TFact> : IFactType
        where TFact : IFact
    {
        /// <summary>
        /// Fact name
        /// </summary>
        public virtual string FactName => typeof(TFact).Name;

        /// <summary>
        /// Compare <see cref="IFactType"/>
        /// </summary>
        /// <param name="factInfo"></param>
        public virtual bool EqualsFactType<TFactType>(TFactType factInfo) where TFactType : IFactType
        {
            return factInfo is FactTypeBase<TFact>;
        }

        /// <summary>
        /// Create an fact of this type. Method created for special facts.
        /// </summary>
        /// <typeparam name="TFactResult"></typeparam>
        /// <returns></returns>
        public virtual TFactResult CreateRuntimeSpecialFact<TFactResult>() where TFactResult : IRuntimeSpecialFact
        {
            var type = typeof(TFact);
            var resultType = typeof(TFactResult);

            if (!resultType.IsAssignableFrom(type))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"{type.FullName} does not implement {resultType.FullName} type.");
            else if (type.GetConstructor(Type.EmptyTypes) == null)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"{type.FullName} doesn't have a default constructor.");


            return (TFactResult)Activator.CreateInstance(type, false);
        }

        /// <summary>
        /// Is it possible to convert a fact type to a <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <returns></returns>
        public virtual bool IsFactType<TFact1>() where TFact1 : IFact
        {
            bool result = typeof(TFact1).IsAssignableFrom(typeof(TFact));
            return result;
        }

        /// <summary>
        /// Try to get a fact from the container.
        /// </summary>
        /// <param name="facts">Set fact.</param>
        /// <param name="fact">Fact.</param>
        /// <returns>True - fact found.</returns>
        /// <exception cref="InvalidOperationException">There are more than one type of inheriting <typeparamref name="TFact"/> type.</exception>
        public virtual bool TryGetFact(IEnumerable<IFact> facts, out IFact fact)
        {
            fact = default;
            List<IFact> result = facts.Where(f => f is TFact).ToList();

            if (result.IsNullOrEmpty())
                return false;
            else if (result.Count == 1)
            {
                fact = result[0];
                return true;
            }

            throw new InvalidOperationException($"There is more than one fact with type {FactName} in the array of facts");
        }
    }
}
