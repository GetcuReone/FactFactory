using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Versioned fact container.
    /// </summary>
    [Obsolete("Use FactContainer. FactContainerBase class has become universal")]
    public class VersionedFactContainer : VersionedFactContainerBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public VersionedFactContainer()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        public VersionedFactContainer(IEnumerable<IFact> facts) : base(facts)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        public VersionedFactContainer(IEnumerable<IFact> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }
    }
}
