using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactParameter (deprecated in 4.0.2)")]
    public abstract class FactParameterBase : BaseFactParameter
    {
        /// <inheritdoc/>
        protected FactParameterBase(string code, object value) : base(code, value)
        {
        }
    }
}
