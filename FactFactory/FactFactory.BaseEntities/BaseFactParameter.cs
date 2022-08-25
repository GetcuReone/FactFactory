using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for parameter.
    /// </summary>
    public abstract class BaseFactParameter : IFactParameter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">parameter code</param>
        /// <param name="value">parameter value</param>
        protected BaseFactParameter(string code, object value)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code), "Code is null or empty.");
            Code = code;
            Value = value;
        }

        /// <inheritdoc/>
        public string Code { get; }

        /// <inheritdoc/>
        public object Value { get; }
    }
}
