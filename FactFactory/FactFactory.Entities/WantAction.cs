using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    public class WantAction : WantActionBase
    {
        /// <inheritdoc/>
        public WantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
        }
    }
}
