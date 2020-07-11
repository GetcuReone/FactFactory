using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    public interface IVersionedFactRule<TFact> : IFactRule<TFact>, IFactTypeVersionInfo
        where TFact : IVersionedFact
    {
    }
}
