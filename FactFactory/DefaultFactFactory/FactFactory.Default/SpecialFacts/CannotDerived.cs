using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <inheritdoc/>
    public class CannotDerived<TFact> : CannotDerivedFactBase<TFact>
        where TFact : IFact
    {

    }
}
