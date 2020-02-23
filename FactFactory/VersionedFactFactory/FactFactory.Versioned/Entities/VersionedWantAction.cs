using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Information about the desired action with the version
    /// </summary>
    public class VersionedWantAction : WantAction, IFactTypeVersionInformation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        public VersionedWantAction(Action<IFactContainer> wantAction, IList<IFactType> factTypes) : base(wantAction, factTypes)
        {
            TypeFactVersion = factTypes.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Type fact version
        /// </summary>
        public IFactType TypeFactVersion { get; }
    }
}
