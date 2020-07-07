using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.SpecialFacts
{
    /// <inheritdoc/>
    public class NotContained<TFact> : NotContainedFactBase<TFact>
        where TFact : IFact
    {
    }
}
