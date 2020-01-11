using FactFactory.Facts;
using FactFactory.Interfaces;
using System;

namespace FactFactory.Entities
{
    /// <inheritdoc />
    public class FactInfo<TFact> : IFactInfo
        where TFact: IFact
    {
        /// <inheritdoc />
        public string FactName => typeof(TFact).Name;

        /// <inheritdoc />
        public bool Compare<TFactInfo>(TFactInfo factInfo) where TFactInfo : IFactInfo
        {
            return factInfo is FactInfo<TFact>;
        }

        /// <inheritdoc />
        public bool ContainsContainer<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer
        {
            return container.Contains<TFact>();
        }

        /// <inheritdoc />
        public INotContainedFact GetNotContainedFact()
        {
            return (INotContainedFact) Activator.CreateInstance(typeof(TFact));
        }

        /// <inheritdoc />
        public bool IsFactType<TFact1>() where TFact1 : IFact
        {
            bool result = typeof(TFact1).IsAssignableFrom(typeof(TFact));
            return result;
        }
    }
}
