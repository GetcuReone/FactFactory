using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact interface
    /// </summary>
    public interface IFact
    {
        /// <summary>
        /// Return fact information as an output parameter
        /// </summary>
        /// <returns></returns>
        IFactType GetFactType();

        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="parameter">Parameter</param>
        void AddParameter(IFactParameter parameter);

        /// <summary>
        /// Find parameter by code
        /// </summary>
        /// <param name="parameterCode">Parameter code</param>
        /// <returns>Fact parameter</returns>
        IFactParameter? FindParameter(string parameterCode);

        /// <summary>
        /// Return parameters of a fact
        /// </summary>
        /// <returns>Fact parameters</returns>
        IReadOnlyCollection<IFactParameter> GetParameters();
    }
}
