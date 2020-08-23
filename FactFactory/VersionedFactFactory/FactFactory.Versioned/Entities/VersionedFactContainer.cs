using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Versioned fact container.
    /// </summary>
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

        /// <summary>
        /// Get copy container.
        /// </summary>
        /// <returns></returns>
        public override IFactContainer Copy()
        {
            return new VersionedFactContainer(this, false);
        }
    }
}
