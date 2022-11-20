using System;

namespace GetcuReone.FactFactory.Interfaces.Operations
{
    /// <summary>
    /// Fact parameter cache.
    /// </summary>
    public interface IFactParameterCache
    {
        /// <summary>
        /// Returns or creates a fact parameter.
        /// </summary>
        /// <param name="parameterCode">Parameter code.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <returns>Fact parameter.</returns>
        IFactParameter GetOrCreate(
            string parameterCode,
            object parameterValue);

        /// <summary>
        /// Returns or creates a fact parameter.
        /// </summary>
        /// <param name="parameterCode">Parameter code.</param>
        /// <param name="parameterValue">Parameter value.</param>
        /// <param name="createParameterFunc">Fact parameter creation method.</param>
        /// <returns>Fact parameter.</returns>
        IFactParameter GetOrCreate(
            string parameterCode,
            object parameterValue,
            Func<string, object, IFactParameter> createParameterFunc);
    }
}
