using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Entities
{
    /// <inheritdoc />
    public class FactType<TFact> : IFactType
        where TFact: IFact
    {
        /// <inheritdoc />
        public string FactName => typeof(TFact).Name;

        /// <inheritdoc />
        public bool Compare<TFactType>(TFactType factInfo) where TFactType : IFactType
        {
            return factInfo is FactType<TFact>;
        }

        /// <inheritdoc />
        public INotContainedFact GetNotContainedInstance()
        {
            var type = typeof(TFact);

            if (!typeof(INotContainedFact).IsAssignableFrom(type))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"Fact is not a type {nameof(INotContainedFact)}");

            return (INotContainedFact) Activator.CreateInstance(typeof(TFact));
        }

        /// <inheritdoc />
        public INoDerivedFact GetNoDerivedInstance()
        {
            var type = typeof(TFact);

            if (!typeof(INoDerivedFact).IsAssignableFrom(type))
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidFactType, $"Fact is not a type {nameof(INoDerivedFact)}");

            return (INoDerivedFact)Activator.CreateInstance(typeof(TFact));
        }

        /// <inheritdoc />
        public bool IsFactType<TFact1>() where TFact1 : IFact
        {
            bool result = typeof(TFact1).IsAssignableFrom(typeof(TFact));
            return result;
        }
    }
}
