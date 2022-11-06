using System;
using System.Collections.Generic;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactWork (deprecated in 4.0.2)")]
    public abstract class FactWorkBase : BaseFactWork
    {
        /// <inheritdoc/>
        protected FactWorkBase(List<IFactType> factTypes, FactWorkOption option) : base(factTypes, option)
        {
        }
    }
}
