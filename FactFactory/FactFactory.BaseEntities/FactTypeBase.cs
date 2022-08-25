using System;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactType (deprecated in 4.0.2)")]
    public abstract class FactTypeBase<TFact> : BaseFactType<TFact>
        where TFact : IFact
    {
    }
}
