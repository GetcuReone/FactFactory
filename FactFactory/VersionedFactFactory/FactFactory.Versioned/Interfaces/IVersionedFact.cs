using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Versioned <see cref="IFact"/>.
    /// </summary>
    public interface IVersionedFact : IFact
    {
        /// <summary>
        /// Version of the rule that calculated the fact.
        /// </summary>
        IVersionFact Version { get; set; }

        /// <summary>
        /// It was calculated using the rule.
        /// </summary>
        bool CalculatedByRule { get; set; }
    }
}
