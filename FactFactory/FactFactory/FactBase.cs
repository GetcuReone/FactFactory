using System;

namespace GetcuReone.FactFactory
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFact (deprecated in 4.0.2)")]
    public abstract class FactBase : BaseFact
    {
    }

    /// <inheritdoc/>
    [Obsolete("Use BaseFact (deprecated in 4.0.2)")]
    public abstract class FactBase<TFactValue> : BaseFact<TFactValue>
    {
        /// <inheritdoc/>
        protected FactBase(TFactValue value) : base(value)
        {
        }
    }
}
