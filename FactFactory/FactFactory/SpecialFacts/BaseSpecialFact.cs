using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="ISpecialFact"/>.
    /// </summary>
    public abstract class BaseSpecialFact : BaseFact, ISpecialFact
    {
        /// <inheritdoc/>
        public abstract bool EqualsInfo(ISpecialFact specialFact);
    }
}
