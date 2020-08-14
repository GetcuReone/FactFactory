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
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact.</param>
        /// <param name="factTypes">facts required to launch an action.</param>
        public VersionedWantAction(Action<IFactContainer> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
        }

    }
}
