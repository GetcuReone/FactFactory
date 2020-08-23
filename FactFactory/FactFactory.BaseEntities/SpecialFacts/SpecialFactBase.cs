using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;

namespace GetcuReone.FactFactory.BaseEntities.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="ISpecialFact"/>.
    /// </summary>
    public abstract class SpecialFactBase : FactBase, ISpecialFact
    {
        /// <inheritdoc/>
        public abstract bool IsFactContained<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer;
    }
}
