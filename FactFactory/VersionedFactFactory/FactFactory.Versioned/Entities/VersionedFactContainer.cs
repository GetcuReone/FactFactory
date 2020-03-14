using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Versioned.Entities
{
    /// <summary>
    /// Versioned fact container.
    /// </summary>
    public class VersionedFactContainer : FactContainerBase<VersionedFactBase>
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
        public VersionedFactContainer(IEnumerable<VersionedFactBase> facts) : base(facts)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="facts">An array of facts to add to the container.</param>
        /// <param name="isReadOnly"></param>
        public VersionedFactContainer(IEnumerable<VersionedFactBase> facts, bool isReadOnly) : base(facts, isReadOnly)
        {
        }

        /// <summary>
        /// Get copy container.
        /// </summary>
        /// <returns></returns>
        public override FactContainerBase<VersionedFactBase> Copy()
        {
            return new VersionedFactContainer(this, false);
        }

        /// <summary>
        /// Return fact type information.
        /// </summary>
        /// <typeparam name="TGetFact">The type of fact to return information about.</typeparam>
        /// <returns></returns>
        protected override IFactType GetFactType<TGetFact>()
        {
            return new FactType<TGetFact>();
        }
    }
}
