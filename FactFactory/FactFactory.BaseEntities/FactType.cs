using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Fact type
    /// </summary>
    public class FactType<TFact> : FactTypeBase<TFact>
        where TFact: IFact
    {
    }
}
