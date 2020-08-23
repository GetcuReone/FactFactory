using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact interface.
    /// </summary>
    public interface IFact
    {
        /// <summary>
        /// Return fact information as an output parameter.
        /// </summary>
        /// <returns></returns>
        IFactType GetFactType();

        /// <summary>
        /// Fact parameters.
        /// </summary>
        IEnumerable<IFactParameter> Parameters { get; }

        /// <summary>
        /// Add parameter.
        /// </summary>
        /// <param name="parameter"></param>
        void AddParameter(IFactParameter parameter);

        /// <summary>
        /// It was calculated using the rule.
        /// </summary>
        bool CalculatedByRule { get; set; }
    }
}
