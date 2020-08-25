using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Information about the desired action with the version.
    /// </summary>
    public class VersionedWantAction : VersionedWantActionBase
    {
        /// <inheritdoc/>
        public VersionedWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
        }
    }
}
