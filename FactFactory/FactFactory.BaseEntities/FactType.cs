using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Fact type.
    /// </summary>
    /// <inheritdoc/>
    public class FactType<TFact> : FactTypeBase<TFact>
        where TFact: IFact
    {
    }
}
