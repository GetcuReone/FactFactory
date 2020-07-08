using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <inheritdoc/>
    public class CanDerived<TFact> : CanDerivedFactBase<TFact>
        where TFact : IFact
    {
    }
}
