using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.SpecialFacts
{
    /// <inheritdoc/>
    public class Contained<TFact> : ContainedFactBase<TFact>
        where TFact : IFact
    {

    }
}
