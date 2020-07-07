using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    public class CannotDerived<TFact> : CannotDerivedFactBase<TFact>
        where TFact : IFact
    {

    }
}
