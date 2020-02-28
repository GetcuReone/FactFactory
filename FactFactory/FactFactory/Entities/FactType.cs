using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact type
    /// </summary>
    public class FactType<TFact> : IFactType
        where TFact: IFact
    {
        /// <summary>
        /// Fact name
        /// </summary>
        public string FactName => typeof(TFact).Name;

        /// <summary>
        /// Compare <see cref="IFactType"/>
        /// </summary>
        /// <param name="factInfo"></param>
        public bool Compare<TFactType>(TFactType factInfo) where TFactType : IFactType
        {
            return factInfo is FactType<TFact>;
        }

        /// <summary>
        /// Return fact. The current fact is not contained in the container.
        /// </summary>
        /// <returns></returns>
        public INotContainedFact CreateNotContained()
        {
            return CreateFact<INotContainedFact>();
        }

        /// <summary>
        /// Return an instance of a type <see cref="INoDerivedFact"/> fact in for the current fact type
        /// </summary>
        /// <returns></returns>
        public INoDerivedFact CreateNoDerived()
        {
            return CreateFact<INoDerivedFact>();
        }

        /// <summary>
        /// Is it possible to convert a fact type to a <typeparamref name="TFact"/>
        /// </summary>
        /// <typeparam name="TFact1"></typeparam>
        /// <returns></returns>
        public bool IsFactType<TFact1>() where TFact1 : IFact
        {
            bool result = typeof(TFact1).IsAssignableFrom(typeof(TFact));
            return result;
        }

        /// <summary>
        /// Try to get a fact from the container.
        /// </summary>
        /// <typeparam name="TFact1">Type base class for facts.</typeparam>
        /// <param name="facts">Set fact.</param>
        /// <param name="fact">Fact.</param>
        /// <returns>True - fact found.</returns>
        /// <exception cref="InvalidOperationException">There are more than one type of inheriting <typeparamref name="TFact"/> type.</exception>
        public bool TryGetFact<TFact1>(IEnumerable<TFact1> facts, out TFact1 fact) where TFact1 : IFact
        {
            fact = default;
            List<TFact1> result = facts.Where(f => f is TFact1 && f is TFact).ToList();

            if (result.IsNullOrEmpty())
                return false;
            else if (result.Count == 1)
            {
                fact = result[0];
                return true;
            }

            throw new InvalidOperationException($"There is more than one fact with type {FactName} in the array of facts");
        }

        private TFactResult CreateFact<TFactResult>()
            where TFactResult : IFact
        {
            var type = typeof(TFact);
            var resultType = typeof(TFactResult);

            if (!resultType.IsAssignableFrom(type))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"{type.FullName} does not implement {resultType.FullName} type");
            else if (type.GetConstructor(Type.EmptyTypes) == null)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"{type.FullName} doesn't have a default constructor");


            return (TFactResult)Activator.CreateInstance(type, false);
        }
    }
}
