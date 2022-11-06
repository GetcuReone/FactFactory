using System;
using System.Collections.Generic;
using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <inheritdoc/>
    [Obsolete("Use BaseFactContainer (deprecated in 4.0.2)")]
    public abstract class FactContainerBase : BaseFactContainer
    {
        /// <inheritdoc/>
        protected FactContainerBase() : base(null)
        {
        }

        /// <inheritdoc/>
        protected FactContainerBase(IEnumerable<IFact> facts) : base(facts, false) 
        {
        }

        /// <inheritdoc/>
        protected FactContainerBase(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }
    }
}
