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
        /// <inheritdoc/>
        public virtual string FactName => typeof(TFact).Name;

        /// <inheritdoc/>
        public virtual bool EqualsFactType<TFactType>(TFactType factInfo) where TFactType : IFactType
        {
            return factInfo is FactTypeBase<TFact>;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public virtual bool IsFactType<TFact1>() where TFact1 : IFact
        {
            bool result = typeof(TFact1).IsAssignableFrom(typeof(TFact));
            return result;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IFact> GetFacts(IEnumerable<IFact> facts)
        {
            return facts.Where(fact => fact is TFact);
        }
    }
}
