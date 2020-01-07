using FactFactory.Interfaces;

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
        public bool ContainsContainer(IFactContainer container)
        {
            return container.Contains<TFact>();
        }
    }
}
