﻿using System.Collections.Generic;

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
        /// Add parameter.
        /// </summary>
        /// <param name="parameter"></param>
        void AddParameter(IFactParameter parameter);

        /// <summary>
        /// Get parameter by code.
        /// </summary>
        /// <param name="parameterCode">Parameter code.</param>
        /// <returns></returns>
        IFactParameter GetParameter(string parameterCode);

        /// <summary>
        /// It was calculated using the rule.
        /// </summary>
        bool CalculatedByRule { get; set; }
    }
}
